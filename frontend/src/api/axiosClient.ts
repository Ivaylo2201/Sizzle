import axios, { AxiosInstance } from "axios";

export const axiosClient: AxiosInstance = axios.create({
  baseURL: import .meta.env.VITE_BACKEND_API_URL,
  headers: {
    'Content-Type': 'application/json'
  },
  withCredentials: true
})