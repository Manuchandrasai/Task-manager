// src/context/TaskContext.js
import React, { createContext, useState, useEffect } from "react";
import * as taskService from "../services/taskService";

export const TaskContext = createContext();

const TaskProvider = ({ children }) => {
  const [tasks,    setTasks]  = useState([]);      // always an array
  const [filter,  setFilter]  = useState("all");

  // 1) Load tasks on mount
  useEffect(() => {
    taskService
      .getTasks()
      .then(res => setTasks(res.data))
      .catch(err => console.error("Fetch failed:", err));
  }, []);

  // 2) Create
  const addTask = (task) => {
    taskService
      .createTask(task)
      .then(res => setTasks(prev => [...prev, res.data]))
      .catch(err => console.error("Create failed:", err));
  };

  // 3) Toggle complete (using the `isComplete` field)
  const toggleComplete = (taskId) => {
    const task = tasks.find(t => t.id === taskId);
    if (!task) return;
    const updated = { ...task, completed: !task.completed };

    taskService
      .updateTask(taskId, updated)
      .then(() => {
        setTasks(prev => prev.map(t => t.id === taskId ? updated : t));
      })
      .catch(err => console.error("Update failed:", err));
  };

  // 4) Delete
  const deleteTask = (taskId) => {
    taskService
      .deleteTask(taskId)
      .then(() => {
        setTasks(prev => prev.filter(t => t.id !== taskId));
      })
      .catch(err => console.error("Delete failed:", err));
  };

  return (
    <TaskContext.Provider
      value={{ tasks, filter, setFilter, addTask, toggleComplete, deleteTask }}
    >
      {children}
    </TaskContext.Provider>
  );
};

export default TaskProvider;
