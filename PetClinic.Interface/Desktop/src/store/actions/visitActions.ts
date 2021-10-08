import { createAsyncThunk } from '@reduxjs/toolkit';
import { visitActions } from 'store/reducers/visitSlice';
import { API_VISIT_INDEX, API_VISIT_CREATE, API_VISIT_UPDATE, API_VISIT_DELETE } from 'constants/endpoints';
import axios from 'libs/axios';

export const getVisits = createAsyncThunk('visit/index', async () => {
	const res = await axios.get(API_VISIT_INDEX);
	return res.data;
});

export const createVisit = createAsyncThunk('visit/create', async (data: any, thunkAPI) => {
	try {
		const res = await axios.post(API_VISIT_CREATE, data);
		if (!res.data.status) throw res.data;
		thunkAPI.dispatch(visitActions.create(res.data.result));
		return res.data;
	} catch (err) {
		return err;
	}
});

export const updateVisit = createAsyncThunk('visit/update', async (data: any, thunkAPI) => {
	try {
		const res = await axios.put(API_VISIT_UPDATE, data);
		if (!res.data.status) throw res.data;
		return res.data;
	} catch (err) {
		return err;
	}
});

export const deleteVisit = createAsyncThunk('visit/delete', async (data: any, thunkAPI) => {
	try {
		const res = await axios.delete(API_VISIT_DELETE, { data });
		if (!res.data.status) throw res.data;
		return res.data;
	} catch (err) {
		return err;
	}
});
