/** @type {import('tailwindcss').Config} */
export default {
  content: ['./index.html', './src/**/*.{js,ts,jsx,tsx}'],
  theme: {
    extend: {
      fontFamily: {
        DMSans: ['DM Sans', 'sans-serif'],
      },
      colors: {
        gunmetal: '#263238',
        'gunmetal-light': '#3e4b52',
        lightgray: '#f0f2f4'
      }
    }
  },
  plugins: []
};
