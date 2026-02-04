# Phase 1.1 Testing Guide

## Testing Checklist for Layout & Navigation Improvements

> **Branch:** `feature/modernization-2024`  
> **Last Updated:** 2024

---

## 🧪 Pre-Testing Setup

### Required Tools:
- Modern browser (Chrome, Edge, Firefox, or Safari)
- Browser DevTools (F12)
- Device simulator or physical devices

### Test Accounts Needed:
- [ ] Admin account
- [ ] Project Manager account
- [ ] Developer account
- [ ] Submitter account
- [ ] Non-authenticated user (logged out)

---

## 📱 Responsive Design Tests

### Test 1: Mobile View (< 768px)
**Viewport:** 375px × 667px (iPhone SE)

#### Steps:
1. Open browser DevTools (F12)
2. Toggle device toolbar (Ctrl+Shift+M)
3. Select "iPhone SE" or set width to 375px
4. Navigate to the application
5. Log in with any account

#### Expected Results:
- [ ] Sidebar is hidden by default
- [ ] Hamburger menu button (☰) is visible in top-left
- [ ] Clicking hamburger opens sidebar with smooth animation
- [ ] Sidebar overlays content (doesn't push it)
- [ ] Dark overlay appears behind sidebar when open
- [ ] Clicking outside sidebar closes it
- [ ] Breadcrumbs display full-width
- [ ] Footer text is centered
- [ ] All text is readable without horizontal scrolling
- [ ] Topbar user menu is accessible

**Screenshot Locations:**
- Mobile with sidebar closed
- Mobile with sidebar open
- Mobile breadcrumb view

---

### Test 2: Tablet View (768px - 991px)
**Viewport:** 768px × 1024px (iPad)

#### Steps:
1. Set viewport to 768px width
2. Navigate through the application
3. Test sidebar toggle

#### Expected Results:
- [ ] Sidebar is visible by default
- [ ] Sidebar toggle button (circular) is visible
- [ ] Clicking toggle collapses sidebar to icon-only view
- [ ] Content expands when sidebar collapses
- [ ] Hamburger menu is hidden
- [ ] Breadcrumbs display properly
- [ ] Navigation items are fully readable

**Screenshot Locations:**
- Tablet with sidebar expanded
- Tablet with sidebar collapsed

---

### Test 3: Desktop View (> 992px)
**Viewport:** 1920px × 1080px (Full HD)

#### Steps:
1. Set viewport to 1920px width
2. Navigate through all pages
3. Test all navigation features

#### Expected Results:
- [ ] Sidebar is fully visible with text labels
- [ ] Circular toggle button works smoothly
- [ ] Collapsed sidebar shows only icons
- [ ] Breadcrumbs align properly with content
- [ ] All menu items are accessible
- [ ] Footer is properly positioned at bottom
- [ ] No layout shifts or jumps

**Screenshot Locations:**
- Desktop with full sidebar
- Desktop with collapsed sidebar

---

## 🧭 Navigation Tests

### Test 4: Sidebar Navigation
#### Steps:
1. Log in as **Admin**
2. Click each navigation item

#### Expected Results:
- [ ] Dashboard link works
- [ ] Company link works
- [ ] Projects collapse menu expands/collapses
- [ ] All project sub-items work:
  - [ ] New Project (Admin/PM only)
  - [ ] My Projects (non-Admin only)
  - [ ] All Projects
  - [ ] Archived Projects
  - [ ] Unassigned Projects (Admin only)
- [ ] Tickets collapse menu expands/collapses
- [ ] All ticket sub-items work:
  - [ ] New Ticket
  - [ ] My Tickets (non-Admin only)
  - [ ] All Tickets
  - [ ] Archived Tickets
  - [ ] Unassigned Tickets (Admin/PM only)

---

### Test 5: Active State Highlighting
#### Steps:
1. Navigate to Dashboard
2. Click on "Projects" → "All Projects"
3. Click on "Tickets" → "My Tickets"
4. Return to Dashboard

#### Expected Results:
- [ ] Dashboard link is highlighted when on Dashboard
- [ ] Projects collapse is highlighted when viewing any project page
- [ ] Tickets collapse is highlighted when viewing any ticket page
- [ ] Active page has bold text or distinct styling
- [ ] Inactive items return to normal styling

---

### Test 6: Breadcrumb Navigation
#### Steps:
1. Navigate to: Home → Projects → All Projects
2. Navigate to: Home → Tickets → Details (click a ticket)
3. Click breadcrumb links to go back

#### Expected Results:
- [ ] Breadcrumb shows: Home
- [ ] Breadcrumb shows: Home → Projects
- [ ] Breadcrumb shows: Home → Projects → AllProjects
- [ ] Breadcrumb shows: Home → Tickets → Details
- [ ] Breadcrumb links are clickable
- [ ] Home icon appears in first breadcrumb
- [ ] Current page is not a link (disabled state)
- [ ] Breadcrumb doesn't show on landing page (logged out)
- [ ] Breadcrumb doesn't show on Dashboard Index

---

### Test 7: Collapse Menu Behavior
#### Steps:
1. Navigate to Projects → All Projects
2. Close the Projects collapse menu
3. Refresh the page

#### Expected Results:
- [ ] Projects collapse menu auto-expands on page load
- [ ] Current project page is visible in the expanded menu
- [ ] Other collapse menus (Tickets) remain closed
- [ ] Collapse animation is smooth (300ms)

---

## 🔐 Role-Based Access Tests

### Test 8: Admin Role
#### Steps:
1. Log in as **Admin**
2. Check sidebar menu items

#### Expected Results:
- [ ] "New Project" is visible
- [ ] "My Projects" is NOT visible (Admin sees all)
- [ ] "All Projects" is visible
- [ ] "Unassigned Projects" is visible
- [ ] "New Ticket" is visible
- [ ] "My Tickets" is NOT visible
- [ ] "Unassigned Tickets" is visible

---

### Test 9: Project Manager Role
#### Steps:
1. Log in as **Project Manager**
2. Check sidebar menu items

#### Expected Results:
- [ ] "New Project" is visible
- [ ] "My Projects" is visible
- [ ] "Unassigned Projects" is NOT visible
- [ ] "New Ticket" is visible
- [ ] "My Tickets" is visible
- [ ] "Unassigned Tickets" is visible

---

### Test 10: Developer/Submitter Role
#### Steps:
1. Log in as **Developer** or **Submitter**
2. Check sidebar menu items

#### Expected Results:
- [ ] "New Project" is NOT visible
- [ ] "My Projects" is visible
- [ ] "Unassigned Projects" is NOT visible
- [ ] "New Ticket" is visible
- [ ] "My Tickets" is visible
- [ ] "Unassigned Tickets" is NOT visible

---

## 🎨 Visual Design Tests

### Test 11: Footer
#### Steps:
1. Navigate to any page
2. Scroll to bottom

#### Expected Results:
- [ ] Footer displays correct copyright text
- [ ] Current year is shown dynamically
- [ ] Footer has subtle background color
- [ ] Footer text is centered
- [ ] Footer stays at bottom (sticky footer)
- [ ] Footer doesn't overlap content

---

### Test 12: Icons & Typography
#### Steps:
1. Review all navigation items
2. Check collapse menu items

#### Expected Results:
- [ ] All icons load properly (Font Awesome)
- [ ] Bug icon shows in brand logo
- [ ] Contextual icons appear in collapse menus:
  - [ ] Plus icon for "New" items
  - [ ] User icon for "My" items
  - [ ] List icon for "All" items
  - [ ] Archive icon for "Archived" items
  - [ ] Question icon for "Unassigned" items
- [ ] Font sizes are consistent
- [ ] Text is readable on all backgrounds

---

### Test 13: Color & Contrast
#### Steps:
1. Review all navigation elements
2. Check hover states

#### Expected Results:
- [ ] Sidebar background is gradient primary color
- [ ] Active items have distinct highlight
- [ ] Hover states are visible
- [ ] Links have proper color contrast
- [ ] Breadcrumb links are blue (#4e73df)
- [ ] Active breadcrumb is gray (#858796)
- [ ] All text meets WCAG AA contrast standards

---

## ♿ Accessibility Tests

### Test 14: Keyboard Navigation
#### Steps:
1. Press Tab key repeatedly
2. Navigate through all menu items
3. Press Enter on focused items

#### Expected Results:
- [ ] All links are keyboard accessible
- [ ] Tab order is logical (top to bottom)
- [ ] Focus indicator is visible (blue outline)
- [ ] Enter key activates links
- [ ] Space bar toggles collapse menus
- [ ] Sidebar toggle button is keyboard accessible
- [ ] Breadcrumb links are keyboard accessible

---

### Test 15: Screen Reader Compatibility
#### Steps:
1. Enable screen reader (NVDA, JAWS, or VoiceOver)
2. Navigate through the page

#### Expected Results:
- [ ] Landmark regions are announced (nav, main, footer)
- [ ] Links announce their purpose
- [ ] Collapse buttons announce their state (expanded/collapsed)
- [ ] Breadcrumb navigation is announced properly
- [ ] ARIA labels are read correctly
- [ ] Heading hierarchy is logical

---

### Test 16: Reduced Motion
#### Steps:
1. Enable "Reduce Motion" in OS settings
2. Toggle sidebar
3. Expand collapse menus

#### Expected Results:
- [ ] Animations still work (no jarring movements)
- [ ] Transitions are faster or instant
- [ ] No spinning/rotating animations persist

---

## 🐛 Edge Case Tests

### Test 17: Landing Page (Not Logged In)
#### Steps:
1. Log out completely
2. Navigate to home page (Index)

#### Expected Results:
- [ ] Minimal sidebar shows only brand logo
- [ ] No navigation menu items visible
- [ ] No breadcrumbs visible
- [ ] Hamburger menu doesn't appear
- [ ] Footer still displays
- [ ] Login/Register links are visible in topbar

---

### Test 18: Window Resize
#### Steps:
1. Start with desktop view (1920px)
2. Slowly resize window to mobile (375px)
3. Resize back to desktop

#### Expected Results:
- [ ] Layout adapts smoothly at each breakpoint
- [ ] No content overlaps or is cut off
- [ ] Sidebar behavior changes appropriately
- [ ] No horizontal scrollbars appear
- [ ] Footer stays at bottom

---

### Test 19: Long Page Names
#### Steps:
1. Navigate to page with long title
2. Check breadcrumb display

#### Expected Results:
- [ ] Long controller names don't break layout
- [ ] Breadcrumbs wrap if necessary
- [ ] Text truncates gracefully on mobile

---

### Test 20: Multiple Rapid Clicks
#### Steps:
1. Rapidly click sidebar toggle button
2. Rapidly click collapse menu items

#### Expected Results:
- [ ] No animation glitches
- [ ] Sidebar opens/closes reliably
- [ ] No JavaScript errors in console
- [ ] State is consistent

---

## 🚀 Performance Tests

### Test 21: Page Load Speed
#### Steps:
1. Open DevTools Network tab
2. Hard refresh page (Ctrl+Shift+R)
3. Measure load times

#### Expected Results:
- [ ] Page loads in < 2 seconds
- [ ] CSS files load without blocking
- [ ] JavaScript executes without errors
- [ ] No console errors
- [ ] No 404 errors for resources

---

### Test 22: Smooth Animations
#### Steps:
1. Toggle sidebar multiple times
2. Expand/collapse menus
3. Monitor frame rate in DevTools

#### Expected Results:
- [ ] Animations run at 60fps
- [ ] No visible stuttering or lag
- [ ] Transitions are smooth (0.3s)
- [ ] No layout thrashing

---

## ✅ Browser Compatibility Tests

### Test Each Browser:
- [ ] Chrome (latest)
- [ ] Edge (latest)
- [ ] Firefox (latest)
- [ ] Safari (latest)
- [ ] Chrome Mobile (Android)
- [ ] Safari Mobile (iOS)

### Expected Results Per Browser:
- [ ] Layout is consistent
- [ ] All features work
- [ ] Animations are smooth
- [ ] No console errors

---

## 📸 Documentation

### Screenshots to Capture:
1. ✅ Desktop - sidebar expanded
2. ✅ Desktop - sidebar collapsed
3. ✅ Tablet - sidebar view
4. ✅ Mobile - sidebar closed
5. ✅ Mobile - sidebar open with overlay
6. ✅ Breadcrumb examples
7. ✅ Active navigation states
8. ✅ Footer on various pages
9. ✅ Collapse menu expanded
10. ✅ Landing page (not logged in)

### Videos to Record:
1. ✅ Mobile hamburger menu demo
2. ✅ Desktop sidebar toggle demo
3. ✅ Collapse menu interaction
4. ✅ Breadcrumb navigation demo
5. ✅ Window resize responsiveness

---

## 📝 Bug Report Template

If you find issues, report them using this format:

```markdown
### Bug: [Short Description]

**Severity:** Critical / High / Medium / Low

**Browser:** Chrome 120 / Firefox 119 / etc.
**Device:** Desktop / iPhone SE / iPad / etc.
**Viewport:** 375px / 768px / 1920px

**Steps to Reproduce:**
1. Navigate to...
2. Click on...
3. Observe...

**Expected Behavior:**
[What should happen]

**Actual Behavior:**
[What actually happens]

**Screenshots:**
[Attach screenshots]

**Console Errors:**
[Any JavaScript errors]

**Additional Notes:**
[Any other relevant information]
```

---

## 🎯 Testing Completion

### Phase 1.1 Testing Status:
- [ ] All 22 tests completed
- [ ] All browsers tested
- [ ] All devices tested
- [ ] Screenshots captured
- [ ] Videos recorded
- [ ] Bugs documented
- [ ] Bugs fixed
- [ ] Retested after fixes

### Sign-Off:
- **Tester Name:** _____________________
- **Date:** _____________________
- **Status:** ⚪ Pass / ⚪ Fail / ⚪ Needs Revision

---

*Ready for Production: ⚪ Yes / ⚪ No*
