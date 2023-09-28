# UScriarUser
=======================================

# 1. Requirements

**USlapr5** Como administrador pretendo criar uma conta de utilizador indicando um número de telefone para contacto direto bem como o tipo de utilizador

The interpretation made of this requirement was that the admin wishes to create users with their personal data like contact name role email and password

# 2. Analysis
* To complete this user story, the classes of creating users must be completed and working
* Should start by inserting the data of the user 
* the us should result on a new active user with certain role, created by the admin

# 3. Design

>   Classes do domínio: User, UserEmail, UserPassword, UserRole, UserContact
>
>   Controlador: UserController
>
>   Repository: UserRepo, 
>
>   Service: UserService
>
>   Router: UserRoute, 
>
>   Schema: UserSchema, 
>
>   Persistence: UserPersistence
>
>   DTO: UserDTO, 
>
>   Mapper: UserMap, 


## 3.1. Realização da Funcionalidade
![SD](createUser.svg)

![SD](inibirUser.svg)

## 3.2. Testes

**Teste 1:** test end2end creating user

 it('creating user success', () => {
      cy.get('[class="textfield"]').should('have.length',6)
      cy.get('[type="text"]').eq(0).type('joao')
      cy.get('[type="text"]').eq(1).type('tiago')
      cy.get('[type="email"]').eq(0).type('joaotiago@gmail.com')
      cy.get('[type="password"]').eq(0).type('Joaotiago1')
      cy.get('[type="text"]').eq(2).type('Logistics_Manager')
      cy.get('[type="number"]').eq(0).type('912323232')

      cy.get('[type="submit"]').should('be.enabled')
      cy.get('[type="submit"]').click()
      cy.get('[class="created-message"]').should('be.visible').contains("User created!")

    })


**Teste 2:** visits list of users and searches one

     it('Visits the list user page', () => {
      cy.visit('/views/list-user')
    })

    it('Searches user success', () => {
      cy.get('[type="text"]').eq(0).type('joaotiago@gmail.com')
      cy.get('[class="ta"]').should('contain','joaotiago@gmail.com')


    })

# 4. Integração/Demonstração


public static create (props: UserCopyProps, id?: UniqueEntityID): Result<UserCopy> {

    const guardedProps = [
      { argument: props.firstName, argumentName: 'firstName' },
      { argument: props.lastName, argumentName: 'lastName' },
      { argument: props.email, argumentName: 'email' },
      { argument: props.password, argumentName: "password" },
      { argument: props.role, argumentName: 'role' },
      { argument: props.userContact, argumentName: 'userContact' },
      { argument: props.active=true, argumentName: 'active' },

    ];

    const guardResult = Guard.againstNullOrUndefinedBulk(guardedProps);

    if (!guardResult.succeeded) {
      return Result.fail<UserCopy>(guardResult.message)
    }     
    else {
      const user = new UserCopy({...props}, id);
      return Result.ok<UserCopy>(user);
    }
  }




