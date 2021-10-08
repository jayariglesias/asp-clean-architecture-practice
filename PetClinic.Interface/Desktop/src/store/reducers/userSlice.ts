import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { getCurrentUser, getUsers } from "store/actions/userActions";
import { UserDto, UserModel } from "store/models/users";

const current: UserModel = {
  userId: null,
  userType: 2,
  firstName: "",
  middleName: "",
  lastName: "",
  username: "",
  password: "",
  email: "",
  pets: undefined
};

const initialState: UserDto = {
  isLoading: false,
  current: current,
  index: null,
};

export const userSlice = createSlice({
  name: "users",
  initialState,
  reducers: {
    create: (state, action: PayloadAction<UserModel>) => {
      state.index?.push(action.payload);
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getUsers.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(getUsers.fulfilled, (state, action) => {
        state.index = action.payload.result;
      });

    builder
      .addCase(getCurrentUser.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(getCurrentUser.fulfilled, (state, action) => {
        state.current = action.payload.result;
      });
  },
});

export const userActions = userSlice.actions;
export default userSlice.reducer;
