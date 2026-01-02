using System;
using System.Linq;
using LibraryAPI.Application.Interfaces;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Infrastructure.Data;
using LibraryAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

public class Tests 
{
    private LibraryDbContext _context;
    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<LibraryDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new LibraryDbContext(options);
    }

    [Test]
    public void TearDown()
    {
        _context?.Dispose();
    }

    [Test]

    public void AddLoan_Should_PersistLoan()
    {
        // Arrange
        var loan = new Loan();
        _context.Set<Loan>().Add(loan);
        _context.SaveChanges();
        Assert.Equals(1, _context.Set<Loan>().Count());
    }
    
    [Test]
    public void RemoveLoan_Should_DeleteLoan()
    {
        // Arrange
        var loan = new Loan();
        _context.Set<Loan>().Add(loan);
        _context.SaveChanges();
        
        // Act
        _context.Set<Loan>().Remove(loan);
        _context.SaveChanges();
        
        // Assert
        Assert.Equals(0, _context.Set<Loan>().Count());
    }

    [Test]
    public void UpdateLoan_Should_ModifyLoan()
    {
        // Arrange
        var loan = new Loan { DueDate = DateTime.Now.AddDays(7) };
        _context.Set<Loan>().Add(loan);
        _context.SaveChanges();
        // Act
        loan.DueDate = DateTime.Now.AddDays(14);
        _context.Set<Loan>().Update(loan);
        _context.SaveChanges();
        // Assert
        var updatedLoan = _context.Set<Loan>().First();
        Assert.Equals(14, (updatedLoan.DueDate - DateTime.Now).Days);
    }
    
    [Test]
    public void QueryLoan_Should_RetrieveLoan()
    {
        // Arrange
        var loan = new Loan();
        _context.Set<Loan>().Add(loan);
        _context.SaveChanges();
        // Act
        var retrievedLoan = _context.Set<Loan>().FirstOrDefault(l => l.Id == loan.Id);
        // Assert
        Assert.IsNotNull(retrievedLoan);
        Assert.Equals(loan.Id, retrievedLoan.Id);
    }
}
