const TodoItem = (taskName) => {
	return (
		<>
			<div className='todo_item'>
				<h1>{taskName}</h1>
				<input type='checkbox' id="checkbox"/>
				<button>Edit</button>
				<button>Delete</button>
			</div>
		</>
	);
};

export default TodoItem;
