package Day56;

public class SortArrayToBST {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	public static BSTreeNode solve(final int[] A){
		return createBST(A, 0, A.length - 1);
	}
	public static BSTreeNode createBST(int arr[],int start,int end){
        if(start>end){
            return null;
        }
        int mid=start+(end-start)/2;
        BSTreeNode temp=new BSTreeNode(arr[mid]);
        temp.left=createBST(arr,start,mid-1);
        temp.right=createBST(arr,mid+1,end);
        return temp;
    }

}
