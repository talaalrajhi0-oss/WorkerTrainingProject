"use client";

import { useState } from "react";

export default function AddWorker() {
  const [name, setName] = useState("");
  const [phoneNum, setPhoneNum] = useState("");
  const [salary, setSalary] = useState("");

  async function addWorker(e: React.FormEvent) {
    e.preventDefault();

    if (name.trim() === "") {
      alert("Name cannot be empty");
      return;
    }

    if (Number(salary) < 0) {
      alert("Salary cannot be negative");
      return;
    }

    if (phoneNum.trim() === "") {
      alert("Phone number cannot be empty");
      return;
    }

    const response = await fetch("http://localhost:5148/api/workers", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        name: name,
        phoneNum: phoneNum,
        salary: Number(salary),
      }),
    });

   if (response.ok) {
  window.location.reload();
} else {
  const message = await response.text();
  alert(message);
}
  }

  return (
    <form onSubmit={addWorker} className="mb-8 space-y-3">
      <h2 className="text-2xl font-bold">Add Worker</h2>


      <input
        type="text"
        placeholder="Name"
        value={name}
        onChange={(e) => setName(e.target.value)}
        className="border p-2 mr-2"
        required
      />

      <input
        type="text"
        placeholder="Phone Number"
        value={phoneNum}
        onChange={(e) => setPhoneNum(e.target.value)}
        className="border p-2 mr-2"
        required
      />

      <input
        type="number"
        step="0.01"
        placeholder="Salary"
        value={salary}
        onChange={(e) => setSalary(e.target.value)}
        className="border p-2 mr-2"
        required
      />

      <button
        type="submit"
        className="bg-blue-600 text-white px-4 py-2 rounded"
      >
        Add Worker
      </button>
    </form>
  );
}