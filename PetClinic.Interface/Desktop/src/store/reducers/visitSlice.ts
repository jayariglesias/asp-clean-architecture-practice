import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { getVisits } from "store/actions/visitActions";
import { VisitDto, VisitModel } from "store/models/visits";

const current: VisitModel = {
  visitId: null,
  petId: null,
  visitType: null,
  visitDate: undefined,
  notes: "",
  pet: undefined,
};

const initialState: VisitDto = {
  isLoading: false,
  current: current,
  index: null,
};

export const visitSlice = createSlice({
  name: "visits",
  initialState,
  reducers: {
    create: (state, action: PayloadAction<VisitModel>) => {
      state.index?.push(action.payload);
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getVisits.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(getVisits.fulfilled, (state, action) => {
        state.index = action.payload.result;
      });
  },
});

export const visitActions = visitSlice.actions;
export default visitSlice.reducer;
