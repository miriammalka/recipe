//This file is equivalent to recipe mainscreen


import { useEffect, useState } from "react";
import { ICookbook, IUsers } from "./DataInterfaces";
import { autoCreateCookbook, fetchCookbooks, fetchUsers } from "./DataUtility";
import CookbookEdit from "./CookbookEdit";
import CookbookList from "./CookbookList";
import { toast } from "react-toastify";
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css'

export default function Cookbooks() {

  const [cookbookId, setCookbookId] = useState(0);
  const [cookbookList, setCookbookList] = useState<ICookbook[]>([]);
  const [users, setUsers] = useState<IUsers[]>([]);
  const [selectedUser, setSelectedUser] = useState<IUsers>()
  const [areButtonsDisabled, setAreButtonsDisabled] = useState(false);
  const [isAutoCreateModalOpen, setIsAutoCreateModalOpen] = useState(false);
  const [modalErrorMessage, setModalErrorMessage] = useState("");


  useEffect(() => {
    const fetchdata = async () => {
      const data = await fetchCookbooks();
      //console.log("fetched cookbooks", data)
      setCookbookList(data);
      setCookbookId(0);
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
    setAreButtonsDisabled(cookbookid === -1);
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
      setCookbookId(updatedcookbook.cookbookId)
    }
  }

  const handleAutoCreateCookbook = async () => {
    console.log("auto create cookbook button clicked")
    if (!selectedUser) {
      setModalErrorMessage("Please select a user before creating a cookbook.");
      return;
    }
    try {
      setModalErrorMessage("")
      const response = await autoCreateCookbook(selectedUser);
      console.log("creating cookbook for user", response);
      if (response.errorMessage) {
        setModalErrorMessage(response.errorMessage)
        return;
      }
      setCookbookList(prevList => [...prevList, response]);
      toast.success('cookbook created successfully!')
      setIsAutoCreateModalOpen(false);

    }
    catch (error: any) {
      setModalErrorMessage(error.message);
    }
  }

  const TableDropdown = ({ rows, setSelectedUser }: { rows: { id: number; name: string }[]; setSelectedUser: (user: IUsers) => void }) => {

    return (
      <div className="dropdown">
        <button className="btn btn-primary dropdown-toggle m-2" type="button" data-bs-toggle="dropdown">
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

  function handleModalClose() {
    setIsAutoCreateModalOpen(false);
    setModalErrorMessage("");
    setSelectedUser(undefined);
  }


  return (
    <div className="row align-items-center mb-3">
      <div className="col-md-10">
        <hr />
        <div className="row">
          <h2>
            <span>
              {cookbookId === 0 ? `${cookbookList.length} Cookbooks` : cookbookId === -1 ? "New Cookbook" : "Edit Cookbook"}
            </span>
          </h2>
        </div>
        <div className="col-md-4 text end">
          {cookbookId === 0 ?
            <div className="row">
              <div className="col-6">
                <button className="btn btn-secondary" style={{ display: 'inline-block', whiteSpace: 'nowrap' }}
                  onClick={() =>  {handleCookbookEdit(-1)}}>New Cookbook</button>
              </div>
              <div className="col-6">
                <button type="button" style={{ display: 'inline-block', whiteSpace: 'nowrap' }} className="btn btn-primary" onClick={() => setIsAutoCreateModalOpen(true)}>
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
            <CookbookList onCookbookEdit={handleCookbookEdit} onAutoCreatCookbook={() => setCookbookList} />
            :
            <CookbookEdit cookbook={cookbookList.find(c => c.cookbookId === cookbookId)!}
              onCancel={() => handleCookbookEdit(0)}
              onCookbookDelete={handleCookbookDelete}
              onCookbookUpdate={handleCookbookUpdate}
              ButtonsDisabled={areButtonsDisabled}
              setButtonsDisabled={setAreButtonsDisabled}
            />
        }
      </div>
      {isAutoCreateModalOpen && (
        <div>
          <div className="modal show fade d-block"
            style={{
              position: 'absolute',
              top: '5px',
            }}
            tabIndex={-1}>
            <div className="modal-dialog">
              <div className="modal-content shadow p-3 mb-5 bg-body-tertiary rounded bg-primary-subtle">
                <div className="modal-header">
                  <h1 className="modal-title fs-5">Auto-Create Cookbook</h1>
                  <button type="button" className="btn-close" onClick={() => handleModalClose()}></button>
                </div>
                <h3>{modalErrorMessage}</h3>
                <div className="modal-body">
                  Please select the user you would like to create a cookbook for:
                </div>
                <div>
                  <TableDropdown rows={tableRows} setSelectedUser={setSelectedUser} />
                </div>
                <div className="modal-footer">
                  <button type="button" className="btn btn-secondary" onClick={() => handleModalClose()}>Close</button>
                  <button type="button" onClick={handleAutoCreateCookbook} className="btn btn-primary">Create Cookbook!</button>
                </div>
              </div>
            </div>
          </div>
        </div>
      )}
      <ToastContainer />
    </div>
  )
}



