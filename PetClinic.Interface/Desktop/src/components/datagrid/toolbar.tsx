import { useState } from 'react';
import {
	GridToolbarColumnsButton,
	GridToolbarDensitySelector,
	GridToolbarFilterButton,
	GridToolbarExport
} from '@mui/x-data-grid/';
import IconButton from '@mui/material/IconButton';
import TextField from '@mui/material/TextField';
import ClearIcon from '@mui/icons-material/Clear';
import SearchIcon from '@mui/icons-material/Search';
import { useStyles } from './themes';
import Grid from '@mui/material/Grid';
import Divider from '@mui/material/Divider';
import DateRangePicker, { DateRange } from '@mui/lab/DateRangePicker';
import AdapterDateFns from '@mui/lab/AdapterDateFns';
import LocalizationProvider from '@mui/lab/LocalizationProvider';
import Box from '@mui/material/Box';

export const Toolbar = (props: { clearSearch: () => void; onChange: () => void; value: string }) => {
	const classes = useStyles();

	return (
		<div className={classes.root}>
			<div>
				<Grid>
					<GridToolbarColumnsButton />
					<GridToolbarFilterButton />
					<GridToolbarDensitySelector />
				</Grid>
			</div>
			<TextField
				variant="standard"
				value={props.value}
				onChange={props.onChange}
				placeholder="Keyword"
				className={classes.textField}
				InputProps={{
					startAdornment: <SearchIcon fontSize="small" />,
					endAdornment: (
						<IconButton
							title="Clear"
							aria-label="Clear"
							size="small"
							style={{ visibility: props.value ? 'visible' : 'hidden' }}
							onClick={props.clearSearch}
						>
							<ClearIcon fontSize="small" />
						</IconButton>
					)
				}}
			/>
		</div>
	);
};
