//This file is equivalent to recipe mainscreen

//import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { useEffect, useState } from "react";
import { ICookbook, IUsers } from "./DataInterfaces";
import { autoCreateCookbook, fetchCookbooks, fetchUsers } from "./DataUtility";
//import { Button } from "@mui/material";
import CookbookEdit from "./CookbookEdit";
import CookbookList from "./CookbookList";
import AutoCreateCookbook from "./AutoCreateCookbook";
import { Modal } from 'bootstrap';

export default function Cookbooks() {

  //const [rowData, setRowData] = useState<ICookbook[]>([]);
  const [cookbookId, setCookbookId] = useState(0);
  const [cookbookList, setCookbookList] = useState<ICookbook[]>([]);
  const [isAutoCreateCookbook, setIsAutoCreateCookbook] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");
  const [users, setUsers] = useState<IUsers[]>([]);
  const [selectedUser, setSelectedUser] = useState<IUsers>()
  //const navigate = useNavigate();


  useEffect(() => {
    const fetchdata = async () => {
      const data = await fetchCookbooks();
      console.log("fetched cookbooks", data)
      setCookbookList(data);
      //setRowData(data);
      setCookbookId(0);
      //if (cookbookId === 0) setCookbookId(0);
    };
    fetchdata();
  }, []);

  useEffect(() => {
    const fetchUsersData = async () => {
      const usersdata = await fetchUsers();
      setUsers(usersdata);
    };
    fetchUsersData();
  }
    , []);

  function handleCookbookEdit(cookbookid: number) {
    console.log("Editing cookbook with ID:", cookbookid);
    setCookbookId(cookbookid);
  };

  function handleCookbookDelete(deletedcookbookid: number) {
    setCookbookList(cookbookList.filter(c => c.cookbookId != deletedcookbookid));
  }

  function handleCookbookUpdate(updatedcookbook: ICookbook) {
    const cookbookExists = cookbookList.some(c => c.cookbookId === updatedcookbook.cookbookId);
    if (cookbookExists) {
      setCookbookList(prevList =>
        prevList.map(c => c.cookbookId === updatedcookbook.cookbookId ? updatedcookbook : c)
      );
    }
    else {
      setCookbookList([...cookbookList, updatedcookbook]);
    }
  }


  //need to work on udating cookbook list when auto create cookbook
  const handleAutoCreateCookbook = async () => {
    console.log("auto create cookbook button clicked")
    if (!selectedUser) {
      setErrorMessage("Please select a user before creating a cookbook.");
      return;
    }
    try {
      setErrorMessage("")
      const response = await autoCreateCookbook(selectedUser);

      console.log("creating cookbook for user", response);

      const updatedCookbooks = await fetchCookbooks();
      setCookbookList([...updatedCookbooks]);
      console.log("Cookbook list updated:", updatedCookbooks);

    }
    catch (error) {
      console.error("Error creating cookbook:", error);
      setErrorMessage("Failed to create cookbook.");
    }
  }



  const TableDropdown = ({ rows, setSelectedUser }: { rows: { id: number; name: string }[]; setSelectedUser: (user: IUsers) => void }) => {
    //const [selectedItem, setSelectedItem] = useState<string | null>(null);

    return (
      <div className="dropdown">
        <button className="btn btn-primary dropdown-toggle" type="button" data-bs-toggle="dropdown">
          {selectedUser ? selectedUser.userName : "Select a User"}
        </button>
        <ul className="dropdown-menu">
          {rows.map((row) => (
            <li key={row.id}>
              <button className="dropdown-item" onClick={() => setSelectedUser({
                usersId: row.id, userName: row.name,
                firstName: "",
                lastName: "",
                errorMessage: ""
              })}>
                {row.name}
              </button>
            </li>
          ))}
        </ul>
      </div>
    );
  };

  const tableRows = users.map((user) => ({
    id: user.usersId,
    name: user.userName
  }));






  //maybe disable cookbookrecipe grid in new cookbook edit screen
  return (
    <div className="row align-items-center mb-3">
      <div className="col-md-10">
        {/* <div className="row">
          <div className="col-2">
            <button className="btn btn-primary">New Cookbook</button>
          </div>
          <div className="col-6">
            <button className="btn btn-primary">Auto-Create Cookbok</button>
          </div>
        </div> */}
        <hr />
        <div className="row">
          <h2>
            <span>
              {cookbookId === 0 ? `${cookbookList.length} Cookbooks` : cookbookId === -1 ? "New Cookbook" : "Edit Cookbook"}
            </span>
          </h2>
        </div>
        <div className="col-md-2 text end">
          {cookbookId === 0 ?
            <div className="row">
              <div className="col-6">
                <button className="btn btn-secondary"
                  onClick={() => setCookbookId(-1)}>New Cookbook</button>
              </div>
              <div className="col-6">
                {/* <button className="btn btn-primary" onClick={() => setIsAutoCreateCookbook(true)}>Auto-Create Cookbok</button> */}
                <button type="button" className="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
                  Auto-Create Cookbook
                </button>
              </div>
            </div>
            :
            <button className="btn btn-secondary m-2" onClick={() => setCookbookId(0)}>Back</button>}
        </div>
      </div>

      <div className="row">
        {
          cookbookId === 0 ?
            isAutoCreateCookbook === true ? <AutoCreateCookbook /> : <CookbookList onCookbookEdit={handleCookbookEdit} onAutoCreatCookbook={() => setCookbookList} />
            :
            <CookbookEdit cookbook={cookbookList.find(c => c.cookbookId === cookbookId)!}
              onCancel={() => handleCookbookEdit(0)}
              onCookbookDelete={handleCookbookDelete}
              onCookbookUpdate={handleCookbookUpdate}
            />
        }
      </div>
      <div>
        <div className="modal fade" id="exampleModal" tabIndex={-1} aria-labelledby="exampleModalLabel" aria-hidden="true">
          <div className="modal-dialog">
            <div className="modal-content">
              <div className="modal-header">
                <h1 className="modal-title fs-5" id="exampleModalLabel">Auto-Create Cookbook</h1>
                <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div className="modal-body">
                Please select the user you would like to create a cookbook for:
              </div>
              <div>
                <TableDropdown rows={tableRows} setSelectedUser={setSelectedUser} />
              </div>
              <div className="modal-footer">
                <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                <button type="button" onClick={handleAutoCreateCookbook} className="btn btn-primary">Create Cookbook!</button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}



