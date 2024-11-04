function manageBaristas(input) {
    const baristas = {};

    function prepare(barista, shift, coffeeType) {
        if (baristas[barista] && baristas[barista].shift === shift && baristas[barista].drinks.includes(coffeeType)) {
            console.log(`${barista} has prepared a ${coffeeType} for you!`);
        } else {
            console.log(`${barista} is not available to prepare a ${coffeeType}.`);
        }
    }

    function changeShift(barista, newShift) {
        if (baristas[barista]) {
            baristas[barista].shift = newShift;
            console.log(`${barista} has updated his shift to: ${newShift}`);
        }
    }

    function learn(barista, newCoffeeType) {
        if (baristas[barista] && !baristas[barista].drinks.includes(newCoffeeType)) {
            baristas[barista].drinks.push(newCoffeeType);
            console.log(`${barista} has learned a new coffee type: ${newCoffeeType}.`);
        } else {
            console.log(`${barista} knows how to make ${newCoffeeType}.`);
        }
    }

    const n = Number(input.shift());
    for (let i = 0; i < n; i++) {
        const [name, shift, drinks] = input[i].split(" ");
        baristas[name] = { shift, drinks: drinks.split(",") };
    }

    for (let i = n; i < input.length; i++) {
        const [action, ...args] = input[i].split(" / ");
        if (action === "Prepare") {
            const [barista, shift, coffeeType] = args;
            prepare(barista, shift, coffeeType);
        } else if (action === "Change Shift") {
            const [barista, newShift] = args;
            changeShift(barista, newShift);
        } else if (action === "Learn") {
            const [barista, newCoffeeType] = args;
            learn(barista, newCoffeeType);
        }
    }

    for (const [barista, details] of Object.entries(baristas)) {
        console.log(`Barista: ${barista}, Shift: ${details.shift}, Drinks: ${details.drinks.join(", ")}`);
    }
}



manageBaristas(['4',
'Alice day Espresso,Cappuccino',
'Bob night Latte,Mocha',
'Carol day Americano,Mocha',
'David night Espresso',
'Prepare / Alice / day / Espresso',
'Change Shift / Bob / day',
'Learn / Carol / Latte',
'Prepare / Bob / night / Latte',
'Learn / David / Cappuccino',
'Prepare / Carol / day / Cappuccino',
'Change Shift / Alice / night',
 'Learn / Bob / Mocha',
'Prepare / David / night / Espresso',
'Closed']
);
