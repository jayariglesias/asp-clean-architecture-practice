import { createAsyncThunk } from '@reduxjs/toolkit';
import { userActions } from 'store/reducers/userSlice';
import axios from 'libs/axios';
import {
	API_USER_INDEX,
	API_USER_CREATE,
	API_USER_UPDATE,
	API_USER_DELETE,
	API_USER_SEARCHBYID
} from 'constants/endpoints';
import { asyncStorage } from 'libs/async-storage';

export const getUsers = createAsyncThunk('user/index', async () => {
	const res = await axios.get(API_USER_INDEX);
	return res.data;
});

export const getCurrentUser = createAsyncThunk('user/current', async () => {
	let auth = await asyncStorage.getItem('AuthStore');
	const res = await axios.get(`${API_USER_SEARCHBYID}/${auth.currentUser.userId}`);
	return res.data;
});

export const createUser = createAsyncThunk('user/create', async (data: any, thunkAPI) => {
	try {
		const res = await axios.post(API_USER_CREATE, data);
		if (!res.data.status) throw res.data;
		thunkAPI.dispatch(userActions.create(res.data.result));
		return res.data;
	} catch (err) {
		return err;
	}
});

export const updateUser = createAsyncThunk('user/update', async (data: any, thunkAPI) => {
	try {
		const res = await axios.put(API_USER_UPDATE, data);
		if (!res.data.status) throw res.data;
		return res.data;
	} catch (err) {
		return err;
	}
});

export const deleteUser = createAsyncThunk('user/delete', async (data: any, thunkAPI) => {
	try {
		const res = await axios.delete(API_USER_DELETE, data);
		if (!res.data.status) throw res.data;
		return res.data;
	} catch (err) {
		return err;
	}
});
