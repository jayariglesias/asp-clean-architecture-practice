import { createTheme, Theme } from '@mui/material/styles';
import { createStyles, makeStyles } from '@mui/styles';

const defaultTheme = createTheme();

export const useStyles = makeStyles(
	(theme: Theme) =>
		createStyles({
			root: {
				padding: theme.spacing(0.5, 0.5, 0),
				justifyContent: 'space-between',
				display: 'flex',
				alignItems: 'center',
				flexWrap: 'wrap'
			},
			textField: {
				[theme.breakpoints.down('xs')]: {
					width: '100%'
				},
				margin: theme.spacing(1, 0.5, 1.5),
				'& .MuiSvgIcon-root': {
					marginRight: theme.spacing(0.5)
				},
				'& .MuiInput-underline:before': {
					borderBottom: `1px solid ${theme.palette.divider}`
				}
			},
			rangePicker: {
				margin: theme.spacing(1, 0.5, 1.5)
			}
		}),
	{ defaultTheme }
);
