function solve(input) {
    let baristas = {};

    // Parse input to create barista objects
    const numberOfBaristas = Number(input.shift());
    for (let i = 0; i < numberOfBaristas; i++) {
        const [name, shift, drinks] = input.shift().split(' ');
        baristas[name] = {
            shift,
            drinks: drinks.split(',')
        };
    }

    // Process commands
    for (const line of input) {
        const [command, ...args] = line.split(' / ');

        if (command === 'Prepare') {
            const [baristaName, shift, coffeeType] = args;

            if (baristas[baristaName].shift === shift && baristas[baristaName].drinks.includes(coffeeType)) {
                console.log(`${baristaName} has prepared a ${coffeeType} for you!`);
            } else {
                console.log(`${baristaName} is not available to prepare a ${coffeeType}.`);
            }
        } else if (command === 'Change Shift') {
            const [baristaName, newShift] = args;
            baristas[baristaName].shift = newShift;
            console.log(`${baristaName} has updated his shift to: ${newShift}`);
        } else if (command === 'Learn') {
            const [baristaName, newDrink] = args;
            if (!baristas[baristaName].drinks.includes(newDrink)) {
                baristas[baristaName].drinks.push(newDrink);
                console.log(`${baristaName} has learned a new coffee type: ${newDrink}.`);
            } else {
                console.log(`${baristaName} knows how to make ${newDrink}.`);
            }
        }
    }

    // Print baristas info
    Object.entries(baristas).forEach(([name, info]) => {
        console.log(`Barista: ${name}, Shift: ${info.shift}, Drinks: ${info.drinks.join(', ')}`);
    });
}
solve(['4',
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
)