import axios from "axios";
import { useState } from "react";

function App() {
	const [inputValue, setInputValue] = useState("");

	const handleChange = (e) => {
		setInputValue(e.target.value);
	};

	// Send Task to Server to DB
	const sendData = async () => {
		try {
			if (!inputValue) {
				throw new Error("Input value is empty");
			}

			const response = await axios.post("http://localhost:5217/api/todo", {
				Id: crypto.randomUUID(),
				Name: inputValue,
				IsComplete: false,
			});
			console.log(response.data);
		} catch (error) {
			console.error("Error sending data:", error);
		}
	};
	// TODO: Render the Todos from DB through components and pass the name through props and state
	const fetchData = async () => {
		try {
			const response = await axios.get("http://localhost:5217/api/todo");

			console.log(response.data);
		} catch (error) {
			console.log(error)
		}
	}

	fetchData();




	return (
		<>
			<div className='todo_list'>
				<input type='text' placeholder='Add a task' value={inputValue} onChange={handleChange} />
				<button onClick={sendData}>Add</button>
				<div className='todo_tasks'></div>
			</div>
		</>
	);
}

export default App;
