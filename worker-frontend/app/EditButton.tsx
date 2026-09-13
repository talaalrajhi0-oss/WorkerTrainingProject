"use client";

import { useState } from "react";

type Props = {
  workerId: number;
  name: string;
  phoneNum: string;
  salary: number;
};

export default function EditButton({
  workerId,
  name,
  phoneNum,
  salary,
}: Props) {
  const [editing, setEditing] = useState(false);

  const [newName, setNewName] = useState(name);
  const [newPhoneNum, setNewPhoneNum] = useState(phoneNum);
  const [newSalary, setNewSalary] = useState(salary.toString());

  async function updateWorker() {
    const response = await fetch(
      `http://localhost:5148/api/workers/${workerId}`,
      {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          workerId: workerId,
          name: newName,
          phoneNum: newPhoneNum,
          salary: Number(newSalary),
        }),
      }
    );

    if (response.ok) {
      window.location.reload();
    } else {
      alert("Failed to update worker");
    }
  }

  if (editing) {
    return (
      <div className="space-y-2">
        <input
          value={newName}
          onChange={(e) => setNewName(e.target.value)}
          className="border p-1"
          placeholder="Name"
        />

        <input
          value={newPhoneNum}
          onChange={(e) => setNewPhoneNum(e.target.value)}
          className="border p-1"
          placeholder="Phone Number"
        />

        <input
          type="number"
          step="0.01"
          value={newSalary}
          onChange={(e) => setNewSalary(e.target.value)}
          className="border p-1"
          placeholder="Salary"
        />

        <button
          onClick={updateWorker}
          className="bg-green-600 text-white px-3 py-1 rounded mr-2"
        >
          Save
        </button>

        <button
          onClick={() => setEditing(false)}
          className="bg-gray-600 text-white px-3 py-1 rounded"
        >
          Cancel
        </button>
      </div>
    );
  }

  return (
    <button
      onClick={() => setEditing(true)}
      className="bg-yellow-500 text-black px-3 py-1 rounded mr-2"
    >
      Edit
    </button>
  );
}