import AddWorker from "./AddWorker";
import DeleteButton from "./DeleteButton";
import EditButton from "./EditButton";
type Worker = {
  workerId: number;
  name: string;
  phoneNum: string;
  salary: number;
};

async function getWorkers(): Promise<Worker[]> {
  const response = await fetch("http://localhost:5148/api/workers", {
    cache: "no-store",
  });

  if (!response.ok) {
    throw new Error("Failed to get workers");
  }

  return response.json();
}

export default async function Home() {
  const workers = await getWorkers();

  return (
    <main className="p-10">
      <h1 className="text-3xl font-bold mb-6">Workers</h1>
 <AddWorker />
      <table className="w-full border-collapse border">
        <thead>
  <tr>
    <th className="border p-3">ID</th>
    <th className="border p-3">Name</th>
    <th className="border p-3">Phone Number</th>
    <th className="border p-3">Salary</th>
    <th className="border p-3">Action</th>
  </tr>
</thead>

<tbody>
  {workers.map((worker) => (
    <tr key={worker.workerId}>
      <td className="border p-3">{worker.workerId}</td>
      <td className="border p-3">{worker.name}</td>
      <td className="border p-3">{worker.phoneNum}</td>
      <td className="border p-3">{worker.salary}</td>

      <td className="border p-3">
        <EditButton
  workerId={worker.workerId}
  name={worker.name}
  phoneNum={worker.phoneNum}
  salary={worker.salary}
/>

        <DeleteButton workerId={worker.workerId} />
      </td>
    </tr>
  ))}
</tbody>
      </table>
    </main>
  );
}