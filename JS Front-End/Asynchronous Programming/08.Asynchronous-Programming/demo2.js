console.log('start!!!');
delayStart(() => console.log('now start!!!'))

delayStart(() => {
    console.log('second start now!!!')
}, 3000);

delayStart(() => {
    console.log('OMG third start now!!!')
}, 4000);

delayStart(() => {
    console.log('And finaly start fuck your self man!!!')
}, 5000);

function delayStart(callback, time = 2000) {
    setTimeout(() => {
        callback();   
    }, time);
}

