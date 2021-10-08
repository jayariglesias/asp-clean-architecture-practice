import styled, { keyframes } from "styled-components";

const Flow = keyframes`
0% {
    top: 0px;
}
50% {
    top: 15px;
}
`;

const Text = styled.div`
  position: relative;
  font-size: 7.5vw;
  text-transform: uppercase;
  padding: 15px;

  &:nth-child(1) span {
    z-index: 0;
    position: relative;
    background: -webkit-linear-gradient(
      rgba(0, 58, 99, 1),
      rgba(0, 58, 99, 1),
      rgba(244, 129, 32, 1)
    );
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    top: 0px;
    animation: ${Flow} 3s infinite;
  }

  &:nth-child(1) :nth-child(1) {
    animation-delay: 0.1s;
  }
  &:nth-child(1) :nth-child(2) {
    animation-delay: 0.2s;
  }
  &:nth-child(1) :nth-child(3) {
    animation-delay: 0.3s;
  }
  &:nth-child(1) :nth-child(4) {
    animation-delay: 0.4s;
  }
  &:nth-child(1) :nth-child(5) {
    animation-delay: 0.5s;
  }
  &:nth-child(1) :nth-child(6) {
    animation-delay: 0.6s;
  }
`;

const Micorn = () => {
  return (
    <Text>
      <span>M</span>
      <span>I</span>
      <span>C</span>
      <span>O</span>
      <span>R</span>
      <span>N</span>
    </Text>
  );
};

export default Micorn;
