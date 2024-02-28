package Day55;

public class DeleteInBST {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	public static BSTTreeNode solve(BSTTreeNode A, int B){
		return DeleteNode(A, B);
	}
	public static BSTTreeNode DeleteNode(BSTTreeNode A, int B){
        if(A==null) {
          return null;
        }
        if(A.val>B){
            A.left=DeleteNode(A.left,B);
        }else if(A.val<B){
            A.right=DeleteNode(A.right,B);
        }else{
            if(A.left==null && A.right==null){
                return null;
            }else if(A.left==null){
                return A.right;
            }else if(A.right==null){
                return A.left;
            }else{
            	BSTTreeNode maxEle=maxNode(A.left);
                A.val=maxEle.val;
                A.left=DeleteNode(A.left,maxEle.val);
            }
        }

        return A;
    }

    public static BSTTreeNode maxNode(BSTTreeNode A) {
        while(A.right != null) {
            A = A.right;
        }
        return A;
    }

}
