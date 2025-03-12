import { useState } from "react"

export default function EmployeeCard({ employee, getEmployees }) {
    const [hide, setHide] = useState(false)
    const [editForm, setEditForm] = useState(false)
    const [roleValue, setRoleValue] = useState(employee.role)

    function toggleMenus() {
        if (hide) {
            setEditForm(false)
        }
        setHide(!hide)
    }

    async function updateEmployee(formData) {
        const response = await fetch(`/api/users/${employee.id}`, {
            method: "put",
            headers: { "Content-Type": "application/json" },
            credentials: "include",
            body: JSON.stringify({
                firstname: formData.get("firstname").length > 0 ? formData.get("firstname") : employee.firstname,
                lastname: formData.get("lastname").length > 0 ? formData.get("lastname") : employee.lastname,
                email: formData.get("email").length > 0 ? formData.get("email") : employee.email,
                role: roleValue
            })
        })

        if (response.ok) {
            alert("Good")
            getEmployees()
        } else {
            alert("Bad")
        }
    }

    return <div className="employeeCard">
        <div className={"employeeAttributes" + (hide ? " isActive" : "")} onClick={toggleMenus}>
            <p>{employee.firstname}</p>
            <p>{employee.lastname}</p>
            <p>{employee.email}</p>
            <p>{employee.role}</p>
            <p>{employee.username}</p>
        </div>
        {
            editForm ?
                <form action={updateEmployee} className="editEmployeeForm">
                    <input type="text" name="firstname" placeholder="New Firstname" />
                    <input type="text" name="lastname" placeholder="New Lastname" />
                    <input type="email" name="email" placeholder="New Email" />
                    <select defaultValue={employee.role} onChange={e => setRoleValue(e.target.value)}>
                        <option value="USER">USER</option>
                        <option value="ADMIN">ADMIN</option>
                    </select>
                    <button type="submit">Update Employee</button>
                </form>
                :
                null
        }
        {
            hide ?
                <div className="employeeMenu">
                    <button onClick={() => setEditForm(!editForm)}>Edit information</button>
                </div>
                :
                null
        }
    </div>
}
