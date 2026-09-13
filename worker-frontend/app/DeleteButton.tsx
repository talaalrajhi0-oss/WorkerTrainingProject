"use client";

type Props = {
  workerId: number;
};

export default function DeleteButton({ workerId }: Props) {
 async function deleteWorker() {
  const confirmed = window.confirm(
    "Are you sure you want to delete this worker?"
  );

  if (!confirmed) {
    return;
  }

  const response = await fetch(
    `http://localhost:5148/api/workers/${workerId}`,
    {
      method: "DELETE",
    }
  );

  if (response.ok) {
    window.location.reload();
  } else {
    alert("Failed to delete worker");
  }
}
  return (
    <button
      onClick={deleteWorker}
      className="bg-red-600 text-white px-3 py-1 rounded"
    >
      Delete
    </button>
  );
}