//I dont think I need this file

export default function AutoCreateCookbook() {
    return (
        <>
            <h2>Auto Create Cookbook</h2>
            <div className="row">
                <div className="col-2">
                    <button className='btn btn-primary'>Back</button>
                </div>
            </div>

            <div className="modal bg-primary" tabIndex={-1}>
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title">Choose a User</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                            <p>Modal body text goes here.</p>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <button type="button" className="btn btn-primary">Save changes</button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}
