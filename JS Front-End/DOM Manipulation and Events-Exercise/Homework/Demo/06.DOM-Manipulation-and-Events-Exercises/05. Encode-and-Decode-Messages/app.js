function encodeAndDecodeMessages() {
    const senderTextarea = document.querySelector('textarea');
    const receiverTextarea = document.querySelector('textarea[disabled]');
    const encodeButton = document.querySelector('button');
    const decodeButton = document.querySelectorAll('button')[1];

    encodeButton.addEventListener('click', function() {
        const message = senderTextarea.value;
        let encodedMessage = '';

        for (let i = 0; i < message.length; i++) {
            // Get the ASCII code of the current character and add 1
            const newCharCode = message.charCodeAt(i) + 1;
            // Convert the new ASCII code back to a character and add it to the encoded message
            encodedMessage += String.fromCharCode(newCharCode);
        }

        // Clear the sender textarea
        senderTextarea.value = '';
        // Add the encoded message to the receiver textarea
        receiverTextarea.value = encodedMessage;
    });

    decodeButton.addEventListener('click', function() {
        const encodedMessage = receiverTextarea.value;
        let decodedMessage = '';

        for (let i = 0; i < encodedMessage.length; i++) {
            // Get the ASCII code of the current character and subtract 1
            const newCharCode = encodedMessage.charCodeAt(i) - 1;
            // Convert the new ASCII code back to a character and add it to the decoded message
            decodedMessage += String.fromCharCode(newCharCode);
        }

        // Replace the encoded message with the decoded message in the receiver textarea
        receiverTextarea.value = decodedMessage;
    });
}