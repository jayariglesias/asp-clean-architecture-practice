import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Title from "components/dashboard/title";
import { VisitModel } from "store/models/visits";

// Generate Visit Mockup Data
const createData = (
  visitId: number,
  petName: string,
  visitType: string,
  visitDate: string,
  notes: string
) => {
  return { visitId, petName, visitType, visitDate, notes };
};

const rows = [
  createData(1, "Jack", "Check Up", "2021-10-11", "good condition"),
  createData(2, "Jimbei", "Others", "2021-10-11", "back on december"),
];

function preventDefault(event: React.MouseEvent) {
  event.preventDefault();
}

export default function Visits() {
  return (
    <>
      <Title>Recent Visits</Title>
      <Table size="small">
        <TableHead>
          <TableRow>
            <TableCell>Date</TableCell>
            <TableCell>Pet</TableCell>
            <TableCell>Visit Type</TableCell>
            <TableCell align="right">Notes</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row) => (
            <TableRow key={row.visitId}>
              <TableCell>{row.visitDate}</TableCell>
              <TableCell>{row.petName}</TableCell>
              <TableCell>{row.visitType}</TableCell>
              <TableCell align="right">{`${row.notes}`}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </>
  );
}
