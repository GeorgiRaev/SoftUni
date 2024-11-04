function solve() {
  const addBtn = document.getElementById('add-btn');
  const taskList = document.getElementById('task-list');
  const doneList = document.getElementById('done-list');

  addBtn.addEventListener('click', function () {
    const placeInput = document.getElementById('place');
    const actionInput = document.getElementById('action');
    const personInput = document.getElementById('person');

    const place = placeInput.value.trim();
    const action = actionInput.value.trim();
    const person = personInput.value.trim();

    if (place === '' || action === '' || person === '') {
      return;
    }

    const li = document.createElement('li');
    li.innerHTML = `<span>${place}</span> - <span>${action}</span> - <span>${person}</span>
                    <button class="edit-btn">Edit</button>
                    <button class="done-btn">Done</button>`;

    taskList.appendChild(li);

    placeInput.value = '';
    actionInput.value = '';
    personInput.value = '';
  });

  taskList.addEventListener('click', function (e) {
    if (e.target.className === 'edit-btn') {
      const task = e.target.parentNode;
      const [place, action, person] = task.textContent.trim().split(' - ');

      document.getElementById('place').value = place;
      document.getElementById('action').value = action;
      document.getElementById('person').value = person;

      taskList.removeChild(task);
    } else if (e.target.className === 'done-btn') {
      const task = e.target.parentNode;
      const [place, action, person] = task.textContent.trim().split(' - ');

      task.removeChild(e.target.previousSibling);
      e.target.textContent = 'Delete';
      e.target.className = 'delete-btn';

      doneList.appendChild(task);
      task.removeChild(task.querySelector('.edit-btn')); // Изтриваме бутона "Edit" от добавения task
    }
  });

  doneList.addEventListener('click', function (e) {
    if (e.target.className === 'delete-btn') {
      const task = e.target.parentNode;
      doneList.removeChild(task);
    }
  });
}

solve();
