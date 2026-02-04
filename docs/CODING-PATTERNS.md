# Coding Patterns & Standards - Twoishday Modernization

> **Established:** Phase 1.1  
> **Last Updated:** 2024  
> **Status:** Active

---

## 🎯 Purpose

This document defines the coding patterns, standards, and best practices established during the modernization effort. All developers should follow these patterns for consistency across the codebase.

---

## 1️⃣ Bootstrap 5 Usage

### ✅ DO: Use Bootstrap 5 Classes

```html
<!-- Spacing utilities -->
<div class="ms-3">Margin-start (left in LTR)</div>
<div class="me-3">Margin-end (right in LTR)</div>
<div class="ps-3">Padding-start</div>
<div class="pe-3">Padding-end</div>

<!-- Display utilities -->
<div class="d-none d-md-block">Hidden on mobile, visible on tablet+</div>
<div class="d-block d-md-none">Visible on mobile, hidden on tablet+</div>

<!-- Flexbox -->
<div class="d-flex justify-content-between align-items-center">
    <span>Left</span>
    <span>Right</span>
</div>
```

### ❌ DON'T: Use Bootstrap 4 Classes

```html
<!-- DON'T USE THESE -->
<div class="ml-3">⛔ Bootstrap 4</div>
<div class="mr-3">⛔ Bootstrap 4</div>
<div class="pl-3">⛔ Bootstrap 4</div>
<div class="pr-3">⛔ Bootstrap 4</div>
<div class="float-left">⛔ Use float-start</div>
<div class="float-right">⛔ Use float-end</div>
```

---

## 2️⃣ Dynamic Active State Detection

### ✅ DO: Use ViewContext for Dynamic States

```csharp
<!-- Navigation item active state -->
<li class="nav-item @(ViewContext.RouteData.Values["controller"]?.ToString() == "Projects" ? "active" : "")">
    <a class="nav-link" asp-controller="Projects" asp-action="Index">
        Projects
    </a>
</li>

<!-- Collapse menu auto-expand -->
<div class="collapse @(ViewContext.RouteData.Values["controller"]?.ToString() == "Tickets" ? "show" : "")" 
     id="collapseTickets">
    <!-- Menu items -->
</div>

<!-- Highlight specific action -->
<a class="nav-link @(ViewContext.RouteData.Values["action"]?.ToString() == "Dashboard" ? "active" : "")"
   asp-action="Dashboard">
    Dashboard
</a>
```

### ❌ DON'T: Use Static Active Classes

```html
<!-- DON'T DO THIS -->
<li class="nav-item active">⛔ Always shows active</li>
```

---

## 3️⃣ Responsive Design Patterns

### ✅ DO: Mobile-First Approach

```css
/* Base styles (mobile) */
.sidebar {
    width: 100%;
    position: fixed;
}

/* Tablet and up */
@media (min-width: 768px) {
    .sidebar {
        width: 14rem;
        position: static;
    }
}

/* Desktop and up */
@media (min-width: 992px) {
    .sidebar {
        width: 16rem;
    }
}
```

### ❌ DON'T: Desktop-First

```css
/* DON'T DO THIS */
.sidebar {
    width: 16rem; /* ⛔ Desktop default */
}

@media (max-width: 768px) {
    .sidebar {
        width: 100%; /* Harder to maintain */
    }
}
```

---

## 4️⃣ Semantic HTML

### ✅ DO: Use Proper Elements

```html
<!-- Navigation -->
<nav aria-label="Main navigation">
    <ul class="navbar-nav">
        <li class="nav-item">
            <a class="nav-link" href="#">Link</a>
        </li>
    </ul>
</nav>

<!-- Breadcrumbs -->
<nav aria-label="breadcrumb">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="#">Home</a></li>
        <li class="breadcrumb-item active" aria-current="page">Current</li>
    </ol>
</nav>

<!-- Footer -->
<footer class="sticky-footer">
    <div class="container">
        <span>&copy; @DateTime.Now.Year Company Name</span>
    </div>
</footer>
```

### ❌ DON'T: Use Generic Divs

```html
<!-- DON'T DO THIS -->
<div class="navigation">⛔ Use <nav></div>
<div class="footer">⛔ Use <footer></div>
<div>
    <div>⛔ Use <ul><li></div>
</div>
```

---

## 5️⃣ Role-Based Rendering

### ✅ DO: Use Roles Enum

```csharp
@using Twoishday.Models.Enums

@if (User.IsInRole(nameof(Roles.Admin)))
{
    <a asp-action="ManageUsers">Manage Users</a>
}

@if (User.IsInRole(nameof(Roles.Admin)) || User.IsInRole(nameof(Roles.ProjectManager)))
{
    <a asp-action="CreateProject">New Project</a>
}

<!-- Opposite logic -->
@if (!User.IsInRole(nameof(Roles.Admin)))
{
    <a asp-action="MyProjects">My Projects</a>
}
```

### ❌ DON'T: Hardcode Role Strings

```csharp
<!-- DON'T DO THIS -->
@if (User.IsInRole("Admin"))  ⛔ Typo-prone
@if (User.IsInRole("admin"))  ⛔ Case-sensitive
```

---

## 6️⃣ Authentication Checks

### ✅ DO: Use SignInManager

```csharp
@inject SignInManager<TDUser> SignInManager

@if (SignInManager.IsSignedIn(User))
{
    <!-- Authenticated content -->
    <nav class="sidebar">...</nav>
}
else
{
    <!-- Public content -->
    <a asp-action="Login">Sign In</a>
}
```

### ❌ DON'T: Check User.Identity Directly

```csharp
<!-- AVOID THIS (less clear) -->
@if (User.Identity?.IsAuthenticated == true)  ⚠️ Works but verbose
```

---

## 7️⃣ Icon Usage

### ✅ DO: Use Contextual Icons

```html
<!-- Font Awesome Icons -->
<i class="fas fa-plus-circle me-1"></i> New Item
<i class="fas fa-user me-1"></i> My Items
<i class="fas fa-list me-1"></i> All Items
<i class="fas fa-archive me-1"></i> Archived
<i class="fas fa-question-circle me-1"></i> Unassigned
<i class="fas fa-home"></i> Home

<!-- Bootstrap Icons -->
<i class="bi bi-check-circle"></i> Success
<i class="bi bi-x-circle"></i> Error
```

### ✅ Icon Sizing & Spacing

```html
<!-- Add margin-end for spacing before text -->
<i class="fas fa-icon me-1"></i> Text

<!-- Size modifiers -->
<i class="fas fa-icon fa-sm"></i> Small
<i class="fas fa-icon"></i> Normal
<i class="fas fa-icon fa-lg"></i> Large
<i class="fas fa-icon fa-2x"></i> 2x
```

---

## 8️⃣ CSS Organization

### ✅ DO: Organize with Section Comments

```css
/* ===== Global Styles ===== */
html {
    font-size: 14px;
}

/* ===== Layout Improvements ===== */
.sidebar {
    /* styles */
}

/* ===== Responsive Overrides ===== */
@media (max-width: 768px) {
    /* mobile styles */
}

/* ===== Accessibility ===== */
.nav-link:focus {
    outline: 2px solid #4e73df;
}
```

### ❌ DON'T: Mix Styles Randomly

```css
/* DON'T DO THIS */
.sidebar { }
.btn { }
.footer { }
@media (max-width: 768px) { }
.card { }
/* ⛔ No organization */
```

---

## 9️⃣ Transitions & Animations

### ✅ DO: Use Standard Timing

```css
/* Standard timing: 0.3s ease-in-out */
.sidebar {
    transition: width 0.3s ease-in-out;
}

.collapse {
    transition: all 0.3s ease-in-out;
}

.card:hover {
    transition: box-shadow 0.3s ease-in-out;
}
```

### ✅ Respect Reduced Motion

```css
@media (prefers-reduced-motion: reduce) {
    * {
        animation-duration: 0.01ms !important;
        transition-duration: 0.01ms !important;
    }
}
```

---

## 🔟 Accessibility (ARIA)

### ✅ DO: Use ARIA Labels

```html
<!-- Navigation landmarks -->
<nav aria-label="Main navigation">...</nav>
<nav aria-label="breadcrumb">...</nav>

<!-- Button states -->
<button aria-expanded="false" aria-controls="collapseMenu">
    Toggle Menu
</button>

<!-- Current page -->
<li class="breadcrumb-item active" aria-current="page">
    Current Page
</li>

<!-- Hidden text for screen readers -->
<span class="visually-hidden">Additional context</span>
```

### ✅ Focus States

```css
/* Visible focus indicators */
.nav-link:focus,
.btn:focus,
a:focus {
    outline: 2px solid #4e73df;
    outline-offset: 2px;
}
```

---

## 1️⃣1️⃣ Razor Syntax Best Practices

### ✅ DO: Null-Safe Navigation

```csharp
<!-- Safe navigation operator -->
@ViewContext.RouteData.Values["controller"]?.ToString()

<!-- Null coalescing -->
@(ViewData["Title"] ?? "Default Title")

<!-- Conditional rendering -->
@if (Model != null)
{
    <div>@Model.Name</div>
}
```

### ✅ String Interpolation

```csharp
<!-- Dynamic classes -->
<div class="card @(isActive ? "active" : "")">

<!-- Inline conditionals -->
@(user.IsAdmin ? "Administrator" : "User")
```

---

## 1️⃣2️⃣ Tag Helpers

### ✅ DO: Use ASP.NET Tag Helpers

```html
<!-- Navigation links -->
<a asp-controller="Home" asp-action="Index">Home</a>
<a asp-controller="Projects" asp-action="Details" asp-route-id="@project.Id">
    @project.Name
</a>

<!-- Forms -->
<form asp-controller="Account" asp-action="Login" method="post">
    <button type="submit">Login</button>
</form>

<!-- Partials -->
<partial name="_LoginPartial" />
```

### ❌ DON'T: Use Url.Action in Views

```html
<!-- AVOID THIS -->
<a href="@Url.Action("Index", "Home")">⚠️ Use tag helpers instead</a>
```

---

## 1️⃣3️⃣ Commenting Standards

### ✅ DO: Comment Intent, Not Implementation

```csharp
<!-- Good Comments -->
@* User navigation - shows different options based on role *@
@if (User.IsInRole(nameof(Roles.Admin)))
{
    <!-- Admin-specific navigation -->
}

<!-- Breadcrumb navigation - auto-hides on landing page -->
@if (ViewContext.RouteData.Values["action"]?.ToString() != "Index")
{
    <nav aria-label="breadcrumb">...</nav>
}
```

### ❌ DON'T: State the Obvious

```csharp
<!-- Bad Comments -->
@* This is a div *@  ⛔
<div>...</div>

@* Loop through projects *@  ⛔
@foreach (var project in Model.Projects)
```

---

## 1️⃣4️⃣ Performance Patterns

### ✅ DO: Use Efficient Selectors

```css
/* Specific, efficient selectors */
.sidebar .nav-link { }
.breadcrumb-item a { }

/* Use classes, not deep nesting */
.card-header { }
```

### ❌ DON'T: Deep Nesting

```css
/* DON'T DO THIS */
.wrapper .container .row .col .card .header .title { }  ⛔
```

### ✅ Minimize Reflows

```css
/* Group layout properties */
.element {
    /* Positioning */
    position: relative;
    top: 0;
    left: 0;
    
    /* Display & Box Model */
    display: flex;
    width: 100%;
    padding: 1rem;
    
    /* Colors */
    background: white;
    color: black;
    
    /* Other */
    transition: all 0.3s;
}
```

---

## 1️⃣5️⃣ Error Handling

### ✅ DO: Defensive Checks

```csharp
<!-- Null checks before accessing properties -->
@if (Model?.Projects?.Any() == true)
{
    @foreach (var project in Model.Projects)
    {
        <div>@project.Name</div>
    }
}
else
{
    <p>No projects found.</p>
}
```

### ✅ Provide Fallbacks

```csharp
<!-- User avatar with fallback -->
@if (user?.AvatarFileData != null)
{
    <img src="data:image/*;base64,@Convert.ToBase64String(user.AvatarFileData)" alt="Avatar">
}
else
{
    <img src="~/images/default-avatar.png" alt="Default Avatar">
}
```

---

## 🎨 Color Palette (SB Admin Theme)

```css
/* Primary Colors */
--primary: #4e73df;
--primary-hover: #2e59d9;

/* Secondary Colors */
--secondary: #858796;
--success: #1cc88a;
--info: #36b9cc;
--warning: #f6c23e;
--danger: #e74a3b;

/* Grays */
--gray-100: #f8f9fc;
--gray-200: #eaecf4;
--gray-300: #dddfeb;
--gray-600: #858796;
--gray-800: #5a5c69;
--gray-900: #3a3b45;
```

---

## 📏 Spacing Scale (Bootstrap 5)

```html
<!-- Spacing: 0, 1, 2, 3, 4, 5 (or rem values) -->
<div class="p-0">No padding</div>
<div class="p-1">0.25rem</div>
<div class="p-2">0.5rem</div>
<div class="p-3">1rem</div>
<div class="p-4">1.5rem</div>
<div class="p-5">3rem</div>

<!-- Directional -->
<div class="pt-3">Padding-top</div>
<div class="pe-3">Padding-end (right)</div>
<div class="pb-3">Padding-bottom</div>
<div class="ps-3">Padding-start (left)</div>
<div class="px-3">Padding horizontal</div>
<div class="py-3">Padding vertical</div>
```

---

## 🚫 Anti-Patterns to Avoid

### ❌ Inline Styles

```html
<!-- DON'T DO THIS -->
<div style="width:600px; height:400px;">⛔</div>

<!-- DO THIS INSTEAD -->
<div class="custom-container">✅</div>
```

```css
.custom-container {
    width: 100%;
    max-width: 600px;
    height: 400px;
}

@media (max-width: 768px) {
    .custom-container {
        height: 300px;
    }
}
```

### ❌ !important Overuse

```css
/* AVOID THIS */
.element {
    color: red !important;  ⛔
}

/* DO THIS - Increase specificity properly */
.sidebar .nav-link {
    color: red;  ✅
}
```

### ❌ Magic Numbers

```css
/* DON'T DO THIS */
.element {
    margin-top: 17px;  ⛔ Why 17?
    padding: 23px;     ⛔ Why 23?
}

/* DO THIS - Use spacing scale */
.element {
    margin-top: 1rem;   /* or mt-3 */  ✅
    padding: 1.5rem;    /* or p-4 */   ✅
}
```

---

## ✅ Code Review Checklist

Before submitting code, verify:

- [ ] Bootstrap 5 classes used (no Bootstrap 4)
- [ ] Semantic HTML elements
- [ ] ARIA labels where appropriate
- [ ] Responsive breakpoints tested
- [ ] Dynamic active states (no static "active" class)
- [ ] Role-based rendering uses `nameof(Roles.xxx)`
- [ ] CSS organized with section comments
- [ ] Transitions use 0.3s ease-in-out
- [ ] Focus states visible
- [ ] No inline styles (except rare cases)
- [ ] No !important (except rare cases)
- [ ] Comments explain intent, not implementation
- [ ] Null checks before property access
- [ ] Fallbacks for images/data

---

## 📚 References

- [Bootstrap 5 Documentation](https://getbootstrap.com/docs/5.3/)
- [WCAG 2.1 Guidelines](https://www.w3.org/WAI/WCAG21/quickref/)
- [ASP.NET Core Tag Helpers](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro)
- [Font Awesome Icons](https://fontawesome.com/icons)
- [Bootstrap Icons](https://icons.getbootstrap.com/)

---

*Established: Phase 1.1*  
*Version: 1.0*  
*Status: Active - To be updated as new patterns emerge*
