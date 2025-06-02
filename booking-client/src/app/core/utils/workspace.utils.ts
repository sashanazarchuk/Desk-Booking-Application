import { Workspace, WorkspaceType } from "../models/workspace.model";

export interface WorkspaceChangeResult {
    showDropdown: boolean;
    showRadioButtons: boolean;
    selectedRoomType: WorkspaceType | null;
    selectedRoomId: number;
}


//Determines the interface state based on the selected workspace.
export function getWorkspaceChangeState(workspaces: Workspace[], selectedWorkspaceId: string): WorkspaceChangeResult {
    const workspace = workspaces.find(w => w.name === selectedWorkspaceId);
    if (!workspace) {
        return {
            showDropdown: false,
            showRadioButtons: false,
            selectedRoomType: null,
            selectedRoomId: 0
        };
    }

    if (workspace.rooms.some(r => r.workspaceType === WorkspaceType.OpenSpace)) {
        return {
            showDropdown: true,
            showRadioButtons: false,
            selectedRoomType: null,
            selectedRoomId: workspace.rooms.find(r => r.workspaceType === WorkspaceType.OpenSpace)?.id || 0
        };
    } else if (workspace.rooms.some(r => r.workspaceType === WorkspaceType.PrivateRoom)) {
        return {
            showDropdown: false,
            showRadioButtons: true,
            selectedRoomType: WorkspaceType.PrivateRoom,
            selectedRoomId: 0
        };
    } else if (workspace.rooms.some(r => r.workspaceType === WorkspaceType.MeetingRoom)) {
        return {
            showDropdown: false,
            showRadioButtons: true,
            selectedRoomType: WorkspaceType.MeetingRoom,
            selectedRoomId: 0
        };
    }

    return {
        showDropdown: false,
        showRadioButtons: false,
        selectedRoomType: null,
        selectedRoomId: 0
    };
}