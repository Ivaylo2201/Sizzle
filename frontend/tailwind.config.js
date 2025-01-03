/** @type {import('tailwindcss').Config} */
export default {
  content: ['./index.html', './src/**/*.{js,ts,jsx,tsx}'],
  theme: {
    extend: {
      fontFamily: {
        DMSans: ['DM Sans', 'sans-serif'],
      },
      colors: {
        'theme-darkgray': '#323232',
        'theme-lightgray': '#f0f2f4',
        'theme-gray': '#4b5563',
        'theme-milk': '#ffebcd',
      }
    }
  },
  plugins: []
};
