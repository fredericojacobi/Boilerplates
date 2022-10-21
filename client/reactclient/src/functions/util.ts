export const log = console.log.bind(document);

export const randomColor = () => `#${Math.floor(Math.random() * 0xffffff).toString(16)}`;

export const isDarkMode = () => window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches;

export const scrollToTop = (element: any) => element.scrollIntoView({behavior: 'smooth', block: 'start'});

export const scrollToBottom = (element: any) => element.scrollIntoView({behavior: 'smooth', block: 'end'});

export const deviceType = () => {
	/Android|webOS|iPhone|iPad|IEMobile|Opera Mini/i.test(navigator.userAgent) ? 'Mobile' : 'Desktop';
};