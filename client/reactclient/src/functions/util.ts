export const log = console.log.bind(document);

export const randomColor = () => `#${Math.floor(Math.random() * 0xffffff).toString(16)}`;

export const isDarkMode = () => window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches;

export const scrollToTop = (element: any) => element.scrollIntoView({behavior: 'smooth', block: 'start'});

export const scrollToBottom = (element: any) => element.scrollIntoView({behavior: 'smooth', block: 'end'});

export const deviceType = () => {
	/Android|webOS|iPhone|iPad|IEMobile|Opera Mini/i.test(navigator.userAgent) ? 'Mobile' : 'Desktop';
};

export const randomAlphaNumericId = (length: number): string => {
	const heyStack = '0123456789abcdefghijklmnopqrstuvwxyz';
	const randomInt = (): number => Math.floor(Math.random() * Math.floor(heyStack.length));

	return Array.from({length}, () => heyStack[randomInt()]).join('');
};

export const parseJwt = (token: string) => {
	try {
		return JSON.parse(atob(token.split('.')[1]));
	}
	catch (e) {
		return null;
	}
};