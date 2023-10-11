const { log } = require('console');
const readline = require('readline');

const rl = readline.createInterface({ input: process.stdin, output: process.stdout });
const prompt = (query) => new Promise((resolve) => rl.question(query, resolve));

const printMenu = () => {
    console.log(`
    Select an option:
        1. List all users
        2. Create new user
        5. Search by first name or last name
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

const searchUsers = (name, users) => {
    if (name.length >= 2) {
        let exists = false;
        users
            .forEach(user => {
                if (user.firstName.toLowerCase() === name.toLowerCase() || user.lastName.toLowerCase() === name.toLowerCase()) {
                    console.log(`ID: ${user.id}, First name: ${user.firstName}, Last name: ${user.lastName}\n`)
                    exists = true;
                }
            })
            
        if (!exists) {
            console.log("The name does not exist!")
        }
    }
    else {
        console.log("Name length too short!")
    }

}

const runProgram = async () => {
    let users = [
        { id: 1, firstName: "Dan", lastName: "Smith" },
        { id: 2, firstName: "John", lastName: "Daniels" },
        { id: 3, firstName: "Marcel", lastName: "John" }
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
                    const newUser = {
                        id: users.length + 1,
                        firstName: await prompt("FirstName:"),
                        lastName: await prompt("Lastname:")
                    }
                    if (newUser.firstName === null || newUser.lastName === null) {
                        console.log("ceva");
                    }

                    users.push(newUser)
                    console.log("User createad succesfully!");
                    break;
                case "5":
                    searchUsers(await prompt("Please enter a first name or a last name: "), users)
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