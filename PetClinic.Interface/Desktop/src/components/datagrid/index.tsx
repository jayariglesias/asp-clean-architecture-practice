import { useState, useEffect } from 'react';
import { DataGrid } from '@mui/x-data-grid';
import { DateRange } from '@mui/lab/DateRangePicker';
import { Toolbar } from './toolbar';
import { Footer } from './footer';
import { DataGridFilterProps as DGFP } from './types';

function escapeRegExp(value: string): string {
	return value.replace(/[-[\]{}()*+?.,\\^$|#\s]/g, '\\$&');
}

const DataGridFilter = (props: {
	isLoading?: boolean;
	height?: number;
	rows?: any;
	columns?: any;
	dataGridProps?: any;
	dateRange?: any;
}) => {
	const [ searchText, setSearchText ] = useState('');
	const [ rangeValue, setRangeValue ] = useState<DateRange<Date>>([ null, null ]);
	const [ array, setArray ] = useState<any[]>([]);

	const requestSearch = (searchValue: string) => {
		setSearchText(searchValue);
		const searchRegex = new RegExp(escapeRegExp(searchValue), 'i');
		const filteredRows = props.rows.filter((row: any) => {
			return JSON.stringify(row).toLowerCase().includes(searchValue.toLowerCase());
			// return Object.keys(row).some((field: any) => {
			//   console.log(searchRegex.test(row[field]))
			//   return searchRegex.test(row[field]);
			// });
		});

		setArray(filteredRows);
	};

	const rangeSearch = (event: DateRange<Date>) => {
		setRangeValue(event);
		console.log(rangeValue);
	};

	useEffect(
		() => {
			setArray(props.rows || []);
		},
		[ props.rows ]
	);

	return (
		<div style={{ height: props.height || 500, width: '100%' }}>
			<DataGrid
				rows={array}
				columns={props.columns}
				components={{ Toolbar, Footer }}
				componentsProps={{
					toolbar: {
						value: searchText,
						onChange: (event: any) => requestSearch(event.target.value),
						clearSearch: () => requestSearch('')
					},
					footer: {
						value: rangeValue,
						dateRange: props.dateRange, // NIREMOVED KO, PANGIT EH
						onChange: (event: any) => rangeSearch(event),
						clearSearch: () => rangeSearch([ null, null ])
					}
				}}
				{...props.dataGridProps}
			/>
		</div>
	);
};

export type DataGridFilterProps = DGFP;
export default DataGridFilter;
