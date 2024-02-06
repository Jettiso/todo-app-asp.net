

import { useState } from "react";

function App() {

	// 	TODO: make a function that sends input data to the server through API
	const [inputValue, setInputValue] = useState("");

	const handleChange = (e) => {
		setInputValue(e.target.value);
	};

	return (
		<>
			<div className='todo_list'>
				<input type='text' placeholder='Add a task' value={inputValue} onChange={handleChange} />
				<button>Add</button>
			</div>
		</>
	);
}

export default App;
