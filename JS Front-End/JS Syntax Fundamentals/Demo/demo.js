var input = prompt(input);
if (input >= 0 && input <= 2) {
    console.log('baby')
} else if (input > 2 && input <= 13) {
    console.log('child')
} else if (input > 13 && input <= 19) {
    console.log('teenager')
} else if (input > 19 && input <= 65) {
    console.log('adult')
} else if (input > 65) {
    console.log('alder')
} else {
    console.log('out of bounds')
}


