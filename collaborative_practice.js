const readline = require('readline');

const rl = readline.createInterface({ input: process.stdin, output: process.stdout });
const prompt = (query) => new Promise((resolve) => rl.question(query, resolve));

const printMenu = () => {
    console.log(`
    Select an option:
        1. List all users
        2. Create new user
        3. Update existing user
        0. Exit
    `);
};

const listUsers = (users) => {
    console.log("\nListing current users:");
    const output = users
        .map(user => `ID: ${user.id}\nFirst name: ${user.firstName}\nLast name: ${user.lastName}\n`)
        .join("\n");
    console.log(output);
};

const createNewUser = async (users) => {
    const firstName = await prompt("First Name: ");
    const lastName = await prompt("Last Name: ");

    if (!firstName || !lastName) {
        console.log("First name and last name are required.");
    } else {
        const newUser = {
            id: users.length + 1,
            firstName: firstName,
            lastName: lastName
        };

        users.push(newUser);
        console.log("User created successfully!");
    }
};

const printUpdateMenu = () => {
    console.log(`
    Select an option:
        1. Update first name
        2. Update last name
        0. Go back
    `);
}

const findUserById = (users, useriId) => {
    return users.find(user => user.id == useriId); 
}

const updateExistingUser = async (users) => {
    
    while(true) {

        console.log("\nUpdate existing user");
        let userId = await prompt("User ID: ");

        const user = findUserById(users, userId);
        console.log(user);

        if (user === undefined) {
            console.log("User with the given id does not exist.");
            return;
        }

        printUpdateMenu();

        let option = await prompt("Option: ");
        switch (option) {
            case "1":
                let newFirstName = await prompt("New First Name: ");
                user.firstName = newFirstName;
                return;
            case "2":
                let newLastName = await prompt("New Last Name: ");
                user.lastName = newLastName;
                return;
            case "0":
                return;
            default:
                console.log("Invalid command!");
        }
    }
}

const runProgram = async () => {
    let users = [
        { id: 1, firstName: "John", lastName: "Smith" }
    ];
    while (true) {
        try {
            printMenu();

            let option = await prompt("Option: ");
            switch (option) {
                case "1":
                    listUsers(users);
                    break;
                case "2":
                    await createNewUser(users)
                    break;
                case "3":
                    await updateExistingUser(users);
                    break;    
                case "0":
                    rl.close();
                    return;
                default:
                    console.log("Invalid command!");
            }
        }
        catch (e) {
            console.error("Unable to read", e);
        }
    }
};

runProgram();