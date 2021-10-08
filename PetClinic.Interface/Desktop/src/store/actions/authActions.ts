import { createAsyncThunk } from '@reduxjs/toolkit';
import { LoginModel } from 'store/models/auth';
import { authActions } from 'store/reducers/authSlice';
import { asyncStorage } from 'libs/async-storage';
import { API_LOGIN } from 'constants/endpoints';
import { store } from 'store';
import axios from 'libs/axios';

export const loginHandler = createAsyncThunk('auth/login', async (data: LoginModel, thunkAPI) => {
	const res = await axios.post(API_LOGIN, data);
	if (!res.data.status) {
		thunkAPI.dispatch(authActions.loginFailed());
		asyncStorage.removeItem('AuthStore');
	} else {
		thunkAPI.dispatch(authActions.loginSuccess(res.data.result));
		asyncStorage.setItem('AuthStore', JSON.stringify(res.data.result));
	}
	return res.data;
});

export const authHandler = createAsyncThunk('auth/asynced', async (any, thunkAPI) => {
	const state = store.getState();
	let token = state.auth.token || null;

	if (!token) {
		let auth = await asyncStorage.getItem('AuthStore');
		if (!auth) return;
		thunkAPI.dispatch(authActions.loginSuccess(auth));
		token = auth.token;
	}

	return token;
});
