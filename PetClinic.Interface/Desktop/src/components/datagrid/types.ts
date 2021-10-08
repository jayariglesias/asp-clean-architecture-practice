/*
 Since walang naka export na type, kinopya ko lang to doon sa modules ng datagrid
*/

export type DataGridFilterProps = {
	/**=
     * Override the height/width of the grid inner scrollbar.
     */
	scrollbarSize?: number;
	/**
     * Function that applies CSS classes dynamically on cells.
     * @param {GridCellParams} params With all properties from [[GridCellParams]].
     * @returns {string} The CSS class to apply to the cell.
     */
	getCellClassName?: (params: any) => string;
	/**
     * Function that applies CSS classes dynamically on rows.
     * @param {GridRowParams} params With all properties from [[GridRowParams]].
     * @returns {string} The CSS class to apply to the row.
     */
	getRowClassName?: (params: any) => string;
	/**
     * Callback fired when a cell is rendered, returns true if the cell is editable.
     * @param {GridCellParams} params With all properties from [[GridCellParams]].
     * @returns {boolean} A boolean indicating if the cell is editable.
     */
	isCellEditable?: (params: any) => boolean;
	/**
     * Determines if a row can be selected.
     * @param {GridRowParams} params With all properties from [[GridRowParams]].
     * @returns {boolean} A boolean indicating if the cell is selectable.
     */
	isRowSelectable?: (params: any) => boolean;
	/**
     * Callback fired when the edit cell value changes.
     * @param {GridEditCellPropsParams} params With all properties from [[GridEditCellPropsParams]].
     * @param {MuiEvent} event The event that caused this prop to be called.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onEditCellPropsChange?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when the cell changes are committed.
     * @param {GridCellEditCommitParams} params With all properties from [[GridCellEditCommitParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event that caused this prop to be called.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onCellEditCommit?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when the cell turns to edit mode.
     * @param {GridCellParams} params With all properties from [[GridCellParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event that caused this prop to be called.
     */
	onCellEditStart?: (params: any, event: any) => void;
	/**
     * Callback fired when the cell turns to view mode.
     * @param {GridCellParams} params With all properties from [[GridCellParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event that caused this prop to be called.
     */
	onCellEditStop?: (params: any, event: any) => void;
	/**
     * Callback fired when the row changes are committed.
     * @param {GridRowId} id The row id.
     * @param {MuiEvent<React.SyntheticEvent>} event The event that caused this prop to be called.
     */
	onRowEditCommit?: (id: any, event: any) => void;
	/**
     * Callback fired when the row turns to edit mode.
     * @param {GridRowParams} params With all properties from [[GridRowParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event that caused this prop to be called.
     */
	onRowEditStart?: (params: any, event: any) => void;
	/**
     * Callback fired when the row turns to view mode.
     * @param {GridRowParams} params With all properties from [[GridRowParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event that caused this prop to be called.
     */
	onRowEditStop?: (params: any, event: any) => void;
	/**
     * Callback fired when an exception is thrown in the grid.
     * @param {any} args The arguments passed to the `showError` call.
     * @param {MuiEvent<{}>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onError?: (args: any, event: any, details: any) => void;
	/**
     * Callback fired when the active element leaves a cell.
     * @param {GridCallbackDetails} params With all properties from [[GridCellParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onCellBlur?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a click event comes from a cell element.
     * @param {GridCellParams} params With all properties from [[GridCellParams]].
     * @param {MuiEvent<React.MouseEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onCellClick?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a double click event comes from a cell element.
     * @param {GridCellParams} params With all properties from [[GridCellParams]].
     * @param {MuiEvent<React.MouseEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onCellDoubleClick?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a cell loses focus.
     * @param {GridCellParams} params With all properties from [[GridCellParams]].
     * @param {MuiEvent<React.SyntheticEvent | DocumentEventMap['click']>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onCellFocusOut?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a keydown event comes from a cell element.
     * @param {GridCellParams} params With all properties from [[GridCellParams]].
     * @param {MuiEvent<React.KeyboardEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onCellKeyDown?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a mouseover event comes from a cell element.
     * @param {GridCellParams} params With all properties from [[GridCellParams]].
     * @param {MuiEvent<React.MouseEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onCellOver?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a mouseout event comes from a cell element.
     * @param {GridCellParams} params With all properties from [[GridCellParams]].
     * @param {MuiEvent<React.MouseEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onCellOut?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a mouse enter event comes from a cell element.
     * @param {GridCellParams} params With all properties from [[GridCellParams]].
     * @param {MuiEvent<React.MouseEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onCellEnter?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a mouse leave event comes from a cell element.
     * @param {GridCellParams} params With all properties from [[GridCellParams]].
     * @param {MuiEvent<React.MouseEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onCellLeave?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when the cell value changed.
     * @param {GridEditCellValueParams} params With all properties from [[GridEditCellValueParams]].
     * @param {MuiEvent<{}>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onCellValueChange?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a click event comes from a column header element.
     * @param {GridColumnHeaderParams} params With all properties from [[GridColumnHeaderParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onColumnHeaderClick?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a double click event comes from a column header element.
     * @param {GridColumnHeaderParams} params With all properties from [[GridColumnHeaderParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onColumnHeaderDoubleClick?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a mouseover event comes from a column header element.
     * @param {GridColumnHeaderParams} params With all properties from [[GridColumnHeaderParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onColumnHeaderOver?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a mouseout event comes from a column header element.
     * @param {GridColumnHeaderParams} params With all properties from [[GridColumnHeaderParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onColumnHeaderOut?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a mouse enter event comes from a column header element.
     * @param {GridColumnHeaderParams} params With all properties from [[GridColumnHeaderParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onColumnHeaderEnter?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a mouse leave event comes from a column header element.
     * @param {GridColumnHeaderParams} params With all properties from [[GridColumnHeaderParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onColumnHeaderLeave?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a column is reordered.
     * @param {GridColumnOrderChangeParams} params With all properties from [[GridColumnOrderChangeParams]].
     * @param {MuiEvent<{}>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onColumnOrderChange?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired while a column is being resized.
     * @param {GridColumnResizeParams} params With all properties from [[GridColumnResizeParams]].
     * @param {MuiEvent<{}>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onColumnResize?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when the width of a column is changed.
     * @param {GridCallbackDetails} params With all properties from [[GridColumnResizeParams]].
     * @param {MuiEvent<{}>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onColumnWidthChange?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a column visibility changes.
     * @param {GridColumnVisibilityChangeParams} params With all properties from [[GridColumnVisibilityChangeParams]].
     * @param {MuiEvent<{}>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onColumnVisibilityChange?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a click event comes from a row container element.
     * @param {GridRowParams} params With all properties from [[GridRowParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onRowClick?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when scrolling to the bottom of the grid viewport.
     * @param {GridRowScrollEndParams} params With all properties from [[GridRowScrollEndParams]].
     * @param {MuiEvent<{}>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onRowsScrollEnd?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a double click event comes from a row container element.
     * @param {GridRowParams} params With all properties from [[RowParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onRowDoubleClick?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a mouseover event comes from a row container element.
     * @param {GridRowParams} params With all properties from [[GridRowParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onRowOver?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a mouseout event comes from a row container element.
     * @param {GridRowParams} params With all properties from [[GridRowParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onRowOut?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a mouse enter event comes from a row container element.
     * @param {GridRowParams} params With all properties from [[GridRowParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onRowEnter?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when a mouse leave event comes from a row container element.
     * @param {GridRowParams} params With all properties from [[GridRowParams]].
     * @param {MuiEvent<React.SyntheticEvent>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onRowLeave?: (params: any, event: any, details: any) => void;
	/**
     * Callback fired when the grid is resized.
     * @param {ElementSize} containerSize With all properties from [[ElementSize]].
     * @param {MuiEvent<{}>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onResize?: (containerSize: any, event: any, details: any) => void;
	/**
     * Callback fired when the state of the grid is updated.
     * @param {GridState} state The new state.
     * @param {MuiEvent<{}>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     * @internal
     */
	onStateChange?: (state: any, event: any, details: any) => void;
	/**
     * Callback fired when the rows in the viewport change.
     * @param {GridViewportRowsChangeParams} params The viewport params.
     * @param {MuiEvent<{}>} event The event object.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onViewportRowsChange?: (params: any, event: any, details: any) => void;
	/**
     * Set the current page.
     * @default 1
     */
	page?: number;
	/**
     * Callback fired when the current page has changed.
     * @param {number} page Index of the page displayed on the Grid.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onPageChange?: (page: number, details: any) => void;
	/**
     * Set the number of rows in one page.
     * @default 100
     */
	pageSize?: number;
	/**
     * Callback fired when the page size has changed.
     * @param {number} pageSize Size of the page displayed on the Grid.
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onPageSizeChange?: (pageSize: number, details: any) => void;
	/**
     * Set the edit rows model of the grid.
     */
	editRowsModel?: any;
	/**
     * Callback fired when the `editRowsModel` changes.
     * @param {GridEditRowsModel} editRowsModel With all properties from [[GridEditRowsModel]].
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onEditRowsModelChange?: (editRowsModel: any, details: any) => void;
	/**
     * Set the filter model of the grid.
     */
	filterModel?: any;
	/**
     * Callback fired when the Filter model changes before the filters are applied.
     * @param {GridFilterModel} model With all properties from [[GridFilterModel]].
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onFilterModelChange?: (model: any, details: any) => void;
	/**
     * Set the selection model of the grid.
     */
	selectionModel?: any;
	/**
     * Callback fired when the selection state of one or multiple rows changes.
     * @param {GridSelectionModel} selectionModel With all the row ids [[GridSelectionModel]].
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onSelectionModelChange?: (selectionModel: any, details: any) => void;
	/**
     * Set the sort model of the grid.
     */
	sortModel?: any;
	/**
     * Callback fired when the sort model changes before a column is sorted.
     * @param {GridSortModel} model With all properties from [[GridSortModel]].
     * @param {GridCallbackDetails} details Additional details for this callback.
     */
	onSortModelChange?: (model: any, details: any) => void;
	/**
     * The label of the grid.
     */
	'aria-label'?: string;
	/**
     * The id of the element containing a label for the grid.
     */
	'aria-labelledby'?: string;
	/**
     * Return the id of a given [[GridRowData]].
     */
	getRowId?: (row: any) => void;
};
