let clicks: any = [];
let interval: number;
/**
 * Note: This is for onCellClick in DataGrid Material.
 * 
 * Callback fired when a single or double click event comes from an element.
 * @param single — trigger when element singled click.
 * @param double — trigger when element doubled click.
 * @param data — props for first function and second function.
 * @example on onDoubleClick
 * ClickHandler(false, (props: any) => console.log(props), props).
 */

const onClick = (single: any, double: any) => (data: React.ChangeEvent<HTMLInputElement>) => {
	clicks.push(new Date().getTime());
	window.clearTimeout(interval);
	interval = window.setTimeout(() => {
		if (clicks.length > 1 && clicks[clicks.length - 1] - clicks[clicks.length - 2] < 250) {
			if (!double) return;
			double({ data });
		} else {
			if (!single) return;
			single({ data });
		}
	}, 250);
};

export { onClick as ClickHandler };
export default onClick;
