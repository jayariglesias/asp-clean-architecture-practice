import { useEffect, useState } from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import FormGroup from '@mui/material/FormGroup';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import Grid from '@mui/material/Grid';
import { VisitDto, VisitFormState, VisitModel } from 'store/models/visits';
import Autocomplete from '@mui/material/Autocomplete';
import { useAppSelector } from 'libs/redux';
import { PetDto } from 'store/models/pets';
import VisitTypes from 'constants/visit-types.json';
import moment from 'moment';
import TextareaAutosize from '@mui/material/TextareaAutosize';
import Divider from '@mui/material/Divider';

export default function AddForm(props: any) {
	const Pets = useAppSelector<PetDto>((state) => state.pet);
	const PetIndex = Pets.index || [];

	const [ values, setValues ] = useState<VisitModel>(props.update || VisitFormState);

	const handleInputChange = (prop: keyof VisitModel) => (event: any) => {
		setValues({ ...values, [prop]: event.target.value });
	};

	const handleComboBoxChange = (prop: keyof VisitModel) => (
		event: React.SyntheticEvent<Element, Event>,
		value: any
	) => {
		let id: number = value.petId || value.visitType;
		setValues({ ...values, [prop]: id });
	};

	useEffect(
		() => {
			props.value(values);
		},
		[ values, props ]
	);

	return (
		<Box
			component="form"
			sx={{
				'& .MuiTextField-root': { mx: 5, my: 1, width: '300px' }
			}}
			autoComplete="off"
		>
			<Typography variant="h5" sx={{ m: 3, fontWeight: 'bold' }}>
				{props.update ? 'Update' : 'Add'} Visit
			</Typography>
			<FormGroup>
				<Autocomplete
					disabled={props.update}
					value={props.update && PetIndex[PetIndex.findIndex((item) => item.petId == props.update.petId)]}
					options={PetIndex}
					getOptionLabel={(option) => option.petName}
					style={{ width: 300 }}
					renderInput={(params) => (
						<TextField {...params} label="Pet Name" variant="outlined" fullWidth required />
					)}
					onChange={handleComboBoxChange('petId')}
				/>
				<TextField
					id="visitDate"
					label="Visit Date"
					type="date"
					value={moment(values.visitDate).format('YYYY-MM-DD')}
					onChange={handleInputChange('visitDate')}
					required
				/>
				<Autocomplete
					value={
						props.update &&
						VisitTypes[VisitTypes.findIndex((item) => item.visitType == props.update.visitType)]
					}
					options={VisitTypes}
					getOptionLabel={(option) => option.visitTypeAlias}
					style={{ width: 300 }}
					onChange={handleComboBoxChange('visitType')}
					renderInput={(params) => (
						<TextField {...params} label="Visit Type" variant="outlined" fullWidth required />
					)}
				/>
				<Divider sx={{ my: 1 }} />
				<Typography sx={{ mx: 5, mt: 2 }}>Notes</Typography>
				<TextareaAutosize
					aria-label="minimum height"
					minRows={10}
					placeholder=" Add Notes"
					id="notes"
					value={values.notes}
					onChange={handleInputChange('notes')}
					style={{ margin: '0px 10.5%' }}
					required
				/>
			</FormGroup>
			<Grid sx={{ mx: 5, my: 1, textAlign: 'right' }}>
				{props.update && (
					<Button variant="contained" type="button" color="tertiary" sx={{ mx: 1 }} onClick={props.onDelete}>
						Delete
					</Button>
				)}
				<Button variant="contained" type="submit" onClick={props.onClick}>
					{props.update ? 'Update' : 'Submit'}
				</Button>
			</Grid>
		</Box>
	);
}
