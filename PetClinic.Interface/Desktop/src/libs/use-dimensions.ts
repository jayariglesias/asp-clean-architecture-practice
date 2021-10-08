import { useEffect, useRef, useState } from 'react';

export const useDimensions = (ref: any) => {
	const dimensions = useRef({ width: 0, height: 0 });

	useEffect(
		() => {
			dimensions.current.width = ref.current.offsetWidth;
			dimensions.current.height = ref.current.offsetHeight;
		},
		[ ref ]
	);

	return dimensions.current;
};

export const useWindowDimensions = () => {
	const [ dimensions, setDimensions ] = useState({ width: 0, height: 0 });

	useEffect(() => {
		const updateWindowDimensions = () => {
			setDimensions({
				width: window.innerWidth,
				height: window.innerHeight
			});
		};

		window.addEventListener('resize', updateWindowDimensions);
		return () => window.removeEventListener('resize', updateWindowDimensions);
	}, []);

	return dimensions;
};
