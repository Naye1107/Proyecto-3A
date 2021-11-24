describe('PruebaGenerica', function() {
    it('Visita la pagina e ingresa datos incorrectos', function() {
      cy.visit('https://localhost:5001/')
      cy.pause()
      cy.get(':nth-child(3) > .nav-link').click()

      //Datos incorrectos
      cy.get('#email').click()
      .type('Rafa@gmail.com')
      cy.get('#pass')
      .type('5555')
      cy.pause()
      cy.get('.my-4 > .btn').click()
      cy.pause()
    })
    
    it('Visita la pagina e ingresa datos correctos', function() {
        cy.visit('https://localhost:5001/')
        cy.pause()
        cy.get(':nth-child(3) > .nav-link').click()
        
        //Datos correctos
        cy.get('#email').click()
        .type('karlaceballos1@hotmail.com')
        cy.get('#pass')
        .type('12345')
        cy.pause()
        cy.get('.my-4 > .btn').click()
      })
})