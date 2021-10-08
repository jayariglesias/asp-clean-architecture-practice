import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { asyncStorage } from 'libs/async-storage';
import { AuthModel } from 'store/models/auth';

const initialState: AuthModel = {
	token: null,
	isLoggedIn: false,
	isLoading: false,
	currentUser: null
};

export const authSlice = createSlice({
	name: 'auth',
	initialState,
	reducers: {
		login: (state) => {
			state.isLoading = true;
		},
		loginSuccess: (state, action: PayloadAction<AuthModel>) => {
			state.isLoggedIn = true;
			state.isLoading = false;
			state.currentUser = action.payload.currentUser;
			state.token = action.payload.token;
		},
		loginFailed: (state) => {
			state.isLoggedIn = false;
			state.isLoading = false;
			state.currentUser = null;
			state.token = null;
		},
		logout: (state) => {
			asyncStorage.removeItem('AuthStore');
			state.isLoggedIn = false;
			state.isLoading = false;
			state.currentUser = null;
			state.token = null;
		}
	}
});

export const authActions = authSlice.actions;
export default authSlice.reducer;
