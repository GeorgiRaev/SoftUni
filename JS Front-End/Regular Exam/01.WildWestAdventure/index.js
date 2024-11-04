function solve(input) {
    let n = Number(input.shift());
    let posse = {};

    for (let i = 0; i < n; i++) {
        let [name, hp, bullets] = input.shift().split(' ');
        hp = Number(hp);
        bullets = Number(bullets);
        posse[name] = { hp, bullets };
    }

    for (const line of input) {
        if (line === 'Ride Off Into Sunset') {
            break;
        }

        let [action, name, ...args] = line.split(' - ');

        switch (action) {
            case 'FireShot':
                if (posse[name].bullets > 0) {
                    fire(name, args[0], posse);
                } else {
                    console.log(`${name} doesn't have enough bullets to shoot at ${args[0]}!`);
                }
                break;
            case 'TakeHit':
                takeHit(name, Number(args[0]), args[1], posse);
                break;
            case 'Reload':
                reload(name, posse);
                break;
            case 'PatchUp':
                patchUp(name, Number(args[0]), posse);
                break;
        }
    }

    printPosse(posse);

    function fire(name, target, posse) {
        posse[name].bullets--;
        console.log(`${name} has successfully hit ${target} and now has ${posse[name].bullets} bullets!`);
    }

    function takeHit(name, damage, attacker, posse) {
        posse[name].hp -= damage;
        if (posse[name].hp > 0) {
            console.log(`${name} took a hit for ${damage} HP from ${attacker} and now has ${posse[name].hp} HP!`);
        } else {
            console.log(`${name} was gunned down by ${attacker}!`);
            delete posse[name];
        }
    }

    function reload(name, posse) {
        if (posse[name].bullets < 6) {
            let bulletsReloaded = Math.min(6 - posse[name].bullets, posse[name].bullets);
            posse[name].bullets += bulletsReloaded;
            console.log(`${name} reloaded ${bulletsReloaded} bullets!`);
        } else {
            console.log(`${name}'s pistol is fully loaded!`);
        }
    }

    function patchUp(name, amount, posse) {
        posse[name].hp += amount;
        if (posse[name].hp >= 100) {            
            console.log(`${name} is in full health!`);
        }
        console.log(`${name} patched up and recovered ${amount} HP!`);
    }

    function printPosse(posse) {
        for (const [name, { hp, bullets }] of Object.entries(posse)) {
            console.log(`${name}
  HP: ${hp}
  Bullets: ${bullets}`);
        }
    }
}
solve((["2",
    "Gus 100 4",
    "Walt 100 5",
    "FireShot - Gus - Bandit",
    "TakeHit - Walt - 100 - Bandit",
    "Reload - Gus",
    "Ride Off Into Sunset"])
)