import { createAsyncThunk } from '@reduxjs/toolkit';
import { petActions } from 'store/reducers/petSlice';
import axios from 'libs/axios';
import { API_PET_INDEX, API_PET_CREATE, API_PET_UPDATE, API_PET_DELETE } from 'constants/endpoints';

export const getPets = createAsyncThunk('pet/index', async () => {
	const res = await axios.get(API_PET_INDEX);
	return res.data;
});

export const createPet = createAsyncThunk('pet/create', async (data: any, thunkAPI) => {
	try {
		const res = await axios.post(API_PET_CREATE, data);
		if (!res.data.status) throw res.data;
		thunkAPI.dispatch(petActions.create(res.data.result));
		return res.data;
	} catch (err) {
		return err;
	}
});

export const updatePet = createAsyncThunk('pet/update', async (data: any, thunkAPI) => {
	try {
		const res = await axios.put(API_PET_UPDATE, data);
		if (!res.data.status) throw res.data;
		return res.data;
	} catch (err) {
		return err;
	}
});

export const deletePet = createAsyncThunk('pet/delete', async (data: any, thunkAPI) => {
	try {
		const res = await axios.delete(API_PET_DELETE, { data });
		if (!res.data.status) throw res.data;
		return res.data;
	} catch (err) {
		return err;
	}
});
