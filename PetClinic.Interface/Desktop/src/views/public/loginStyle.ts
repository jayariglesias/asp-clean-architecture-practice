import Grid from '@mui/material/Grid';
import Paper from '@mui/material/Paper';
import VetSVG from 'assets/vet.svg';
import styled from 'styled-components';

export const Container = styled(Grid)`
  height: 100vh;
  background: url(${VetSVG});
  background-size: 75%;
  background-repeat: no-repeat;
  background-position: top 0px left 0px;
  @media (max-width: 600px) {
    background-position: bottom -20px left 0px;
  }
`;

export const Main = styled(Paper)`
  width: 1200px;
  margin: auto;
`;

export const Section = styled(Grid)`
  display: flex;
  justify-content: center;
  align-items: center;
`;

export const FormBox = styled.form`
	display: flex;
	justify-content: center;
	flex-direction: column;
	width: 50%;

	@media (max-width: 600px) {
		width: 100%;
		height: 90%;
		margin: 20px;
	}
`;
