// src/services/taskService.js
import axios from "axios";

const API_URL = process.env.REACT_APP_API_URL;
// e.g. in .env.local: REACT_APP_API_URL=http://localhost:5106/api/tasks

export const getTasks   = () => axios.get(API_URL);
export const createTask = (task) => axios.post(API_URL, task);
export const updateTask = (id, task) => axios.put(`${API_URL}/${id}`, task);
export const deleteTask = (id) => axios.delete(`${API_URL}/${id}`);
