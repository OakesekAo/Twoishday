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
- [Chart.js Documentation](https://www.chartjs.org/docs/latest/)

---

## 1️⃣6️⃣ Empty State Pattern

### ✅ DO: Provide User-Friendly Empty States

```html
<!-- Empty state with icon and message -->
<div class="empty-state">
    <i class="fas fa-inbox"></i>
    <p>No tickets assigned to you</p>
</div>

<!-- Empty state with call-to-action -->
<div class="empty-state">
    <i class="fas fa-folder-open"></i>
    <p>No projects found</p>
    <a asp-controller="Projects" asp-action="Create" class="btn btn-primary mt-2">
        <i class="fas fa-plus me-1"></i> Create Your First Project
    </a>
</div>

<!-- Conditional rendering with empty state -->
@if (Model.Tickets != null && Model.Tickets.Any())
{
    <ul class="ticket-list">
        @foreach (var ticket in Model.Tickets)
        {
            <li>@ticket.Title</li>
        }
    </ul>
}
else
{
    <div class="empty-state">
        <i class="fas fa-ticket-alt"></i>
        <p>No tickets available</p>
    </div>
}
```

### ✅ Empty State CSS

```css
.empty-state {
    text-align: center;
    padding: 2rem;
    color: #858796;
}

.empty-state i {
    font-size: 3rem;
    margin-bottom: 1rem;
    opacity: 0.3;
}

.empty-state p {
    margin-bottom: 0;
}
```

### ❌ DON'T: Leave Empty Sections Blank

```html
<!-- DON'T DO THIS -->
@if (Model.Tickets.Any())
{
    <!-- Show tickets -->
}
<!-- ⛔ Nothing shown when empty - confusing UX -->
```

---

## 1️⃣7️⃣ Chart.js Integration

### ✅ DO: Use Chart.js for Data Visualization

```razor
@* In the View *@
<div class="chart-container">
    <canvas id="myChart"></canvas>
</div>

@section Scripts {
    <script>
        var ctx = document.getElementById('myChart').getContext('2d');
        var myChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: [@Html.Raw(string.Join(",", Model.Labels.Select(l => $"'{l}'")))],
                datasets: [{
                    label: 'Dataset',
                    data: [@Html.Raw(string.Join(",", Model.Data))],
                    backgroundColor: '#4e73df'
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    </script>
}
```

### ✅ Chart Container CSS

```css
.chart-container {
    position: relative;
    height: 300px;
}

@media (max-width: 768px) {
    .chart-container {
        height: 250px;
    }
}
```

### ✅ Chart Types

```javascript
// Doughnut Chart (for proportions)
type: 'doughnut'

// Bar Chart (for comparisons)
type: 'bar'

// Line Chart (for trends)
type: 'line'

// Pie Chart (avoid - use doughnut instead)
type: 'pie'  // ⚠️ Doughnut is more modern
```

---

## 1️⃣8️⃣ Feature-Specific CSS Files

### ✅ DO: Create Separate CSS Files for Features

```html
<!-- In the view -->
@section Styles {
    <link href="~/css/dashboard.css" rel="stylesheet" asp-append-version="true" />
}
```

**File Structure:**
```
wwwroot/css/
├── site.css          (global styles)
├── sb-admin-2.min.css (theme)
├── landing.css       (landing page)
├── dashboard.css     (dashboard)
├── projects.css      (projects feature)
└── tickets.css       (tickets feature)
```

### ✅ CSS File Organization

```css
/* dashboard.css */

/* ===== KPI Cards ===== */
.kpi-card { }

/* ===== Charts ===== */
.chart-container { }

/* ===== Activity Feed ===== */
.activity-feed { }

/* ===== Responsive ===== */
@media (max-width: 768px) {
    /* Mobile styles */
}
```

### ❌ DON'T: Put Everything in site.css

```css
/* DON'T DO THIS */
/* site.css with 5000+ lines mixing all features */  ⛔
```

---

## 1️⃣9️⃣ KPI/Metric Card Pattern

### ✅ DO: Use Gradient Cards for Metrics

```html
<div class="col-12 col-sm-6 col-lg-4 col-xl-2">
    <div class="card kpi-card kpi-card-primary shadow">
        <div class="card-body">
            <div class="d-flex justify-content-between align-items-center">
                <div>
                    <div class="kpi-value">@Model.TotalProjects</div>
                    <div class="kpi-label">Total Projects</div>
                </div>
                <div class="kpi-icon">
                    <i class="fas fa-folder"></i>
                </div>
            </div>
        </div>
    </div>
</div>
```

### ✅ KPI Card CSS

```css
.kpi-card {
    border-radius: 0.5rem;
    transition: transform 0.2s ease-in-out, box-shadow 0.2s ease-in-out;
    border: none;
}

.kpi-card:hover {
    transform: translateY(-5px);
    box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15) !important;
}

.kpi-value {
    font-size: 2rem;
    font-weight: bold;
}

.kpi-label {
    font-size: 0.875rem;
    text-transform: uppercase;
    opacity: 0.8;
}

.kpi-icon {
    font-size: 2rem;
    opacity: 0.3;
}

/* Gradient colors */
.kpi-card-primary {
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    color: white;
}
```

---

## 2️⃣0️⃣ Badge Color System

### ✅ DO: Use Consistent Badge Colors

```html
<!-- Status badges -->
<span class="badge badge-status-new">New</span>
<span class="badge badge-status-in-progress">In Progress</span>
<span class="badge badge-status-resolved">Resolved</span>
<span class="badge badge-status-closed">Closed</span>

<!-- Priority badges -->
<span class="badge badge-priority-urgent">Urgent</span>
<span class="badge badge-priority-high">High</span>
<span class="badge badge-priority-medium">Medium</span>
<span class="badge badge-priority-low">Low</span>
```

### ✅ Badge CSS

```css
/* Status Badges */
.badge-status-new {
    background-color: #1cc88a;
}

.badge-status-in-progress {
    background-color: #36b9cc;
}

.badge-status-resolved {
    background-color: #858796;
}

.badge-status-closed {
    background-color: #5a5c69;
}

/* Priority Badges */
.badge-priority-urgent {
    background-color: #e74a3b;
}

.badge-priority-high {
    background-color: #f6c23e;
}

.badge-priority-medium {
    background-color: #36b9cc;
}

.badge-priority-low {
    background-color: #858796;
}
```

### ✅ Dynamic Badge Classes

```csharp
<!-- Convert status name to CSS class -->
<span class="badge badge-status-@ticket.TicketStatus.Name.ToLower().Replace(" ", "-")">
    @ticket.TicketStatus.Name
</span>

<!-- Convert priority to CSS class -->
<span class="badge badge-priority-@ticket.TicketPriority.Name.ToLower()">
    @ticket.TicketPriority.Name
</span>
```

### ❌ DON'T: Use Generic Badge Colors

```html
<!-- DON'T DO THIS -->
<span class="badge bg-success">@status</span>  ⛔ Not semantic
<span class="badge bg-primary">@priority</span>  ⛔ Not consistent
```

---

## 2️⃣1️⃣ Activity Feed/Timeline Pattern

### ✅ DO: Use Timeline Design for Activity

```html
<ul class="activity-feed">
    @foreach (var activity in Model.RecentActivity)
    {
        <li class="activity-feed-item status-@activity.Status.ToLower()">
            <div class="activity-feed-content">
                <strong>@activity.Title</strong>
                <br />
                <small class="text-muted">@activity.Description</small>
            </div>
            <div class="activity-feed-time">
                @activity.Timestamp.ToString("MMM dd, yyyy h:mm tt")
            </div>
        </li>
    }
</ul>
```

### ✅ Activity Feed CSS

```css
.activity-feed {
    list-style: none;
    padding-left: 0;
}

.activity-feed-item {
    position: relative;
    padding-bottom: 1.5rem;
    padding-left: 2rem;
    border-left: 2px solid #e3e6f0;
}

.activity-feed-item:last-child {
    border-left-color: transparent;
}

.activity-feed-item::before {
    content: '';
    position: absolute;
    left: -6px;
    top: 0;
    width: 10px;
    height: 10px;
    border-radius: 50%;
    background-color: #4e73df;
    border: 2px solid white;
}

/* Color-coded by status */
.activity-feed-item.status-new::before {
    background-color: #1cc88a;
}
```

---

## 2️⃣2️⃣ Dictionary to Chart Data Binding

### ✅ DO: Use Html.Raw for Safe Binding

```csharp
@* In Controller *@
model.ChartData = items
    .GroupBy(i => i.Category)
    .ToDictionary(g => g.Key, g => g.Count());

@* In View - Labels *@
labels: [@Html.Raw(string.Join(",", Model.ChartData.Keys.Select(k => $"'{k}'")))]

@* In View - Data *@
data: [@Html.Raw(string.Join(",", Model.ChartData.Values))]
```

### ❌ DON'T: Use @Model Directly in JavaScript

```javascript
// DON'T DO THIS
labels: @Model.Labels  ⛔ Won't serialize properly
data: @Model.Data      ⛔ Wrong format
```

---

## 2️⃣3️⃣ User-Scoped Data Retrieval

### ✅ DO: Use UserManager and Service Methods

```csharp
// In Controller
private readonly UserManager<TDUser> _userManager;
private readonly ITDProjectService _projectService;
private readonly ITDTicketService _ticketService;

public async Task<IActionResult> Dashboard()
{
    // Get user ID with UserManager
    string userId = _userManager.GetUserId(User);
    int companyId = User.Identity.GetCompanyId().Value;

    // Get user-scoped data with service methods
    List<Project> userProjects = await _projectService.GetUserProjectsAsync(userId);
    List<Ticket> userTickets = await _ticketService.GetTicketsByUserIdAsync(userId, companyId);

    return View(model);
}
```

### ❌ DON'T: Use Claims Directly or Company-Wide Data

```csharp
// DON'T DO THIS
string userId = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;  ⛔

// DON'T DO THIS - Shows ALL company data instead of user's
List<Project> allProjects = await _companyInfoService.GetAllProjectsAsync(companyId);  ⛔
List<Ticket> allTickets = allProjects.SelectMany(p => p.Tickets).ToList();  ⛔
```

### ✅ Pattern: Dashboard Data Scoping

```csharp
// Dashboard should show USER's data, not company-wide
model.Projects = await _projectService.GetUserProjectsAsync(userId);
model.Tickets = await _ticketService.GetTicketsByUserIdAsync(userId, companyId);

// Calculate KPIs from user's data only
model.TotalProjects = model.Projects.Count;
model.OpenTickets = model.Tickets.Count(t => t.TicketStatus.Name != "Resolved");
```

---

## 2️⃣4️⃣ Clickable KPI Cards

### ✅ DO: Wrap Cards in Links

```html
<!-- Clickable KPI card -->
<div class="col-12 col-sm-6 col-lg-4 col-xl-2">
    <a asp-controller="Projects" asp-action="MyProjects" class="text-decoration-none">
        <div class="card kpi-card kpi-card-primary shadow">
            <div class="card-body">
                <div class="d-flex justify-content-between align-items-center">
                    <div>
                        <div class="kpi-value">@Model.TotalProjects</div>
                        <div class="kpi-label">My Projects</div>
                    </div>
                    <div class="kpi-icon">
                        <i class="fas fa-folder"></i>
                    </div>
                </div>
            </div>
        </div>
    </a>
</div>
```

### ✅ CSS for Clickable Cards

```css
/* Clickable card links */
a:has(.kpi-card) {
    display: block;
}

a:has(.kpi-card):hover .kpi-card {
    transform: translateY(-5px);
    box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15) !important;
}
```

### ❌ DON'T: Use JavaScript for Navigation

```html
<!-- DON'T DO THIS -->
<div class="card" onclick="window.location='/Projects/MyProjects'">  ⛔
```

---

## ✅ Updated Code Review Checklist

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
- [ ] **Empty states for all dynamic lists/sections**
- [ ] **Feature-specific CSS in separate file**
- [ ] **Chart.js properly initialized in Scripts section**
- [ ] **Badge colors follow system (status/priority)**
- [ ] **Dictionary data properly bound with Html.Raw**
- [ ] **User ID retrieved with `_userManager.GetUserId(User)`**
- [ ] **Data scoped to user (not company-wide) where appropriate**
- [ ] **KPI cards wrapped in `<a>` tags for navigation**

---

## 📚 References

- [Bootstrap 5 Documentation](https://getbootstrap.com/docs/5.3/)
- [WCAG 2.1 Guidelines](https://www.w3.org/WAI/WCAG21/quickref/)
- [ASP.NET Core Tag Helpers](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro)
- [Font Awesome Icons](https://fontawesome.com/icons)
- [Bootstrap Icons](https://icons.getbootstrap.com/)
- [Chart.js Documentation](https://www.chartjs.org/docs/latest/)

---

*Established: Phase 1.1*  
*Updated: Phase 1.3 (Dashboard patterns added)*  
*Version: 1.1*  
*Status: Active - To be updated as new patterns emerge*
