function calc() {
    // TODO: sum = num1 + num2
    const firstInputElement = document.getElementById('num1');
    const secondInputElement = document.getElementById('num2');
    const sumInputElement = document.getElementById('sum');

    const firstNumber = Number(firstInputElement.value);
    const secondNumber = Number(secondInputElement.value);
    const result = firstNumber+secondNumber;
    sumInputElement.value = result;
    
}
