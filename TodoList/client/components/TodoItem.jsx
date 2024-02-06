
const TodoItem = (taskName) => {
	return (
        <>
            <div className="todo_item">
                <h1>{taskName}</h1>
                <button>Finish</button>
                <button>Edit</button>
                <button>Delete</button>
            </div>
        </>
    );
};

export default TodoItem;
