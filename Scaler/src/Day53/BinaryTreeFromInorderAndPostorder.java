package Day53;

public class BinaryTreeFromInorderAndPostorder {

	public static void main(String[] args) {
		int[] A = new int[] { 2, 1, 3 }, B = new int[] { 2, 3, 1 };
		TreeNode ans = buildTree(A, B);
		TreeNode.printPreOrderTree(ans);
	}
	
	public static TreeNode buildTree(int[] A, int[] B) {
        int is=0, ie=A.length-1;
        int ps=0, pe=B.length-1;
       
        TreeNode root=create(B,ps,pe,A,is,ie);
        
        return root;
    }

	public static TreeNode create(int[] post, int ps, int pe, int[] in, int is, int ie) {
        if(ps > pe || is > ie){
            return null;
        }
        
        TreeNode root=new TreeNode(post[pe]);
        int ind=-1;
        for(int j=is; j<= ie; j++) {
            if( in[j] == post[pe] ) {
                ind=j;
                break;
            }
        }
        
        int count=ind-is;
        root.left=create(post,ps,ps+count-1, in , is, ind-1);
        root.right= create(post, ps+count, pe-1, in , ind+1,ie);
        return root;
    }
}
