import { configureStore, ThunkAction, Action } from '@reduxjs/toolkit';
import authReducer from 'store/reducers/authSlice';
import userReducer from 'store/reducers/userSlice';
import petReducer from 'store/reducers/petSlice';
import visitReducer from 'store/reducers/visitSlice';

export const store = configureStore({
	reducer: {
		auth: authReducer,
		user: userReducer,
		pet: petReducer,
		visit: visitReducer
	}
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<ReturnType, RootState, unknown, Action<string>>;
