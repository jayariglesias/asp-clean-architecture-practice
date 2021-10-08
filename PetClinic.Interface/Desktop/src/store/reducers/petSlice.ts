import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { getPets } from "store/actions/petActions";
import { PetDto, PetModel } from "store/models/pets";

const initialState: PetDto = {
  isLoading: false,
  current: null,
  index: null,
};

export const petSlice = createSlice({
  name: "pets",
  initialState,
  reducers: {
    create: (state, action: PayloadAction<PetModel>) => {
      state.index?.push(action.payload);
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getPets.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(getPets.fulfilled, (state, action) => {
        state.index = action.payload.result;
      });
  },
});

export const petActions = petSlice.actions;
export default petSlice.reducer;
